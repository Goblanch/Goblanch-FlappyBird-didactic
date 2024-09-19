using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab references")]
    public GameObject obstacle;
    public GameObject coin;

    [Header("Spawner Config")]
    public float spawnCooldown = 2f;
    public float yRange = 3f;
    [Range(0f, 1f)]
    public float coinSpawnProbability = 0.5f;

    private float _spawnTimer;

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer() {
        _spawnTimer += Time.deltaTime;

        if(_spawnTimer >= spawnCooldown) {
            // Spawneamos 
            SpawnObstacle();
            _spawnTimer = 0;
        }
    }

    private void SpawnObstacle() {
        // Movemos el spawner a una posición aleatoria en Y manteniendo X
        this.transform.position = new Vector2(transform.position.x, Random.Range(-yRange, yRange));
        // Spawneamos el obstáculo
        GameObject obstacleSpawned = Instantiate(obstacle, this.transform.position, Quaternion.identity);
        if (CheckCoinSpawnProbability()) {
            Instantiate(coin, this.transform.position, Quaternion.identity, obstacleSpawned.transform);
        }
    }

    private bool CheckCoinSpawnProbability() {
        return Random.Range(0f, 1f) < coinSpawnProbability;
    }
}
