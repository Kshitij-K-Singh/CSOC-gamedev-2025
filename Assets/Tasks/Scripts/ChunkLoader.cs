using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public GameObject spikes;
    public GameObject chunkPrefab;
    public float max_difficulty = 1f; // Maximum difficulty level
    public float growth_rate = 0.05f; // Growth rate of difficulty
    public float player_x; // Player's x position
    public int chunkSize = 26; // Size of each chunk
    public int look_ahead_distance = 30; // Distance at which chunks are loaded
    public float generatetrigger;
    private float moveSpeed = 8f;
    private float jumpingPower = 20f;
    private float gravity = 4f;
    public int chunkIndex = 0; // Current chunk index
    public int chunksAhead = 2;    // How many chunks ahead to generate
    public int chunksBehind = 2;
    public float amplitude = 2f; // Amplitude of the platform height
    public float frequency = 1.0f; // Frequency of the platform height
    public float phase = 0.0f; // Phase shift of the platform height
    public float base_height = -15.6f; // Base height of the platform
    public float min_gap = 6f; // Minimum gap size between platforms
    public float gap_variance = 4f; // Variance in gap size
    public float gap_frequency = 0.2f; // Frequency of the gap noise
    public float noiseScale = 0.1f; // Scale for the noise function
    private Dictionary<int, GameObject> activeChunks = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> activeSpikes = new Dictionary<int, GameObject>();
    public GameObject HidespotPrefab;
    private Dictionary<int, GameObject> activeHidespot = new Dictionary<int, GameObject>();
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        player_x = player.transform.position.x;
        generatetrigger = player_x + look_ahead_distance;
        chunkIndex = Mathf.FloorToInt(generatetrigger / chunkSize);

        int startIndex = chunkIndex - chunksBehind;
        int endIndex = chunkIndex + chunksAhead;

        for (int i = startIndex; i <= endIndex; i++)
        {
            if (!activeChunks.ContainsKey(i))
            {
                GenerateChunk(i);
            }
        }
        List<int> chunksToRemove = new List<int>();
        foreach (int index in activeChunks.Keys)
        {
            if (index < startIndex || index > endIndex)
            {
                chunksToRemove.Add(index);
            }
        }
        foreach (int index in chunksToRemove)
        {
            Destroy(activeSpikes[index]);
            activeSpikes.Remove(index);

            if (activeHidespot.ContainsKey(index))
            {
                Destroy(activeHidespot[index]);
                activeHidespot.Remove(index);
            }

            Destroy(activeChunks[index]);
            activeChunks.Remove(index);
        }
    }

    void GenerateChunk(int index)
    {
        float maxJumpDistance = MaxJumpableDistance();
        float dF = Difficulty(index);
        float gap = Gap_size(index, dF, maxJumpDistance); // Adjust gap size based on difficulty
        float height = Platform_height(index); // Adjust height based on difficulty
        Vector3 position = new Vector3(index * chunkSize + gap, height, 0f); // Adjust Y/Z if needed
        float platform_x = index * chunkSize + gap; // X position of the platform
        float spike_x = Random.Range(platform_x - 9, platform_x + 9); // Random X position for spikes
        Vector3 spikePosition = new Vector3(spike_x, height + 8.3f, 0f); // Position for spikes
        GameObject chunk = Instantiate(chunkPrefab, position, Quaternion.identity);
        GameObject Spike = Instantiate(spikes, spikePosition, Quaternion.identity);
        activeChunks[index] = chunk;
        activeSpikes[index] = Spike;


        if (index > chunkIndex && (index + 1) % 4 == 0)
        {
            Vector3 hidespotpos = new Vector3(platform_x, height + 9.25f, -1f);
            GameObject hidespot = Instantiate(HidespotPrefab, hidespotpos, Quaternion.identity);
            activeHidespot[index] = hidespot;
        }
    }
    float Platform_height(float x)
    {
        return amplitude * Mathf.Sin(frequency * x + phase) + base_height;
    }
    float Gap_size(float x, float diff, float maxJump)
    {
        float gap = min_gap + Mathf.PerlinNoise(x * gap_frequency, 0) * gap_variance * diff;
        return Mathf.Min(gap, maxJump * 0.9f);
    }
    float Difficulty(int index)
    {
        float difficultyfactor = Mathf.Exp(-growth_rate * index);
        return max_difficulty * (1 - difficultyfactor);
    }

    float MaxJumpableDistance()
    {
        float timeToPeak = jumpingPower / gravity;
        float totalAirTime = 2f * timeToPeak;
        return moveSpeed * totalAirTime;
    }
}
