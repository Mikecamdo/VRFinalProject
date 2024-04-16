using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2.0f;
    public int numberOfSpawns = 5;

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        // Loop through the number of spawns
        for (int i = 0; i < numberOfSpawns; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);

            // Spawn the object at a certain position
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
