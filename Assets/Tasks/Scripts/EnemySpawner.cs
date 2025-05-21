using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    private float spawnTime = 3f;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnTime, enemyPrefab));
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy(float spawnTime, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnTime);
        Vector2 spawnPosition = new Vector2(Random.Range(0, 8f), Random.Range(-4f, 4f));
        Instantiate(enemy, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemy(spawnTime, enemy));
    }
}
