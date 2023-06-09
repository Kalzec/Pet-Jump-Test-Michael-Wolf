using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab of the obstacle object
    public int poolSize = 5; // Number of obstacles to create in the pool
    public float spawnIntervalMin = 1f; // Minimum time interval between obstacle spawns
    public float spawnIntervalMax = 3f; // Maximum time interval between obstacle spawns
    public float obstacleSpeed = 5f; // Speed at which the obstacles move

    private List<GameObject> obstaclePool; // Pool of obstacle objects
    private float nextSpawnTime; // Time to spawn the next obstacle

    private void Start()
    {
        obstaclePool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.Euler(-90,90,90));
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }

        nextSpawnTime = Time.time; // Set the initial spawn time
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax); // Calculate the next spawn time
        }

        for (int i = 0; i < obstaclePool.Count; i++)
        {
            if (obstaclePool[i].activeInHierarchy && obstaclePool[i].transform.position.x < -8f)
            {
                obstaclePool[i].SetActive(false);
            }
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = GetPooledObstacle();

        if (obstacle != null)
        {
            obstacle.transform.position = new Vector3(8f, 0.641f, 0f);
            obstacle.SetActive(true);

            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();
            obstacleRigidbody.velocity = new Vector2(-obstacleSpeed, 0f);
        }
    }

    private GameObject GetPooledObstacle()
    {
        for (int i = 0; i < obstaclePool.Count; i++)
        {
            if (!obstaclePool[i].activeInHierarchy)
                return obstaclePool[i];
        }

        return null;
    }
}
