using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public GameObject player;
    public ChunkLoader chunkLoader; // Reference to the ChunkLoader script
    public int chunkIndex;// Current chunk index from ChunkLoader
    public Vector2 playerPos;
    public float playerPos_x;
    public float playerPos_y;
    readonly private float spawnTime = 3f;
    public int chunkSize = 26; // Size of each chunk
    public int enemyCount = 2; // Number of enemies to spawn

    public void Update()
    {
        if (player == null || chunkLoader == null)
            return;

        chunkIndex = chunkLoader.chunkIndex; // Get the current chunk index from ChunkLoader
        playerPos = player.transform.position;
        playerPos_x = playerPos.x;
        playerPos_y = playerPos.y;
        if (chunkIndex % 4 == 0 && chunkIndex != 0 && enemyCount > 0)
        {
            StartCoroutine(SpawnEnemy(spawnTime, enemyPrefab, enemyCount, 0)); // Start spawning enemies every 3 chunks
            enemyCount = 0; // Reset enemy count after spawning
        }
        else if (chunkIndex % 4 != 0 && chunkIndex != 0)
        {
            enemyCount = 2; // Reset enemy count if not in the right chunk
            StopAllCoroutines(); // Stop spawning enemies if not in the right chunk
        }
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy(float spawnTime, GameObject[] enemy, int maxEnemies, int index)
    {
        if (index > 3) // Check if index exceeds the number of enemy types
        {
            yield break; // Stop spawning if index exceeds the number of enemy types
        }
        else
        {
            if (maxEnemies <= 0)
            {
                maxEnemies = 2; // Reset max enemies to 2
                StartCoroutine(SpawnEnemy(spawnTime, enemy, maxEnemies, index + 1));
            }
            else
            {
                yield return new WaitForSeconds(spawnTime);
                Vector2 spawnPosition = new Vector2(Random.Range(playerPos_x + 5f, playerPos_x + 8f), Random.Range(playerPos_y + 4f, playerPos_y + 7f));
                Instantiate(enemy[index], spawnPosition, Quaternion.identity);
                StartCoroutine(SpawnEnemy(spawnTime, enemy, maxEnemies - 1, index)); // Decrease the count of max enemies
            }

        }
    }
}
