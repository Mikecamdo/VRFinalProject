using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject commonTarget;
    public GameObject uncommonTarget;
    public GameObject rareTarget;
    public GameObject legendaryTarget;

    public bool coroutinesFinished = false;

    public void StartGame()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnCommonTargets());
        StartCoroutine(SpawnUncommonTargets());
        StartCoroutine(SpawnRareTargets());
        StartCoroutine(SpawnLegendaryTargets());
    }

    private IEnumerator SpawnCommonTargets()
    {
        // Loop through the number of spawns
        for (int i = 0; i < 10; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(2f);

            // Spawn 5 common targets
            SpawnCommon();
            SpawnCommon();
            SpawnCommon();
            SpawnCommon();
            SpawnCommon();
        }
    }

    private IEnumerator SpawnUncommonTargets()
    {
        // Loop through the number of spawns
        for (int i = 0; i < 7; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(3f);

            // Spawn 3 uncommon targets
            SpawnUncommon();
            SpawnUncommon();
            SpawnUncommon();
        }
    }

    private IEnumerator SpawnRareTargets()
    {
        // Loop through the number of spawns
        for (int i = 0; i < 5; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(4f);

            // Spawn 2 rare targets
            SpawnRare();
            SpawnRare();
        }
    }

    private IEnumerator SpawnLegendaryTargets()
    {
        // Loop through the number of spawns
        for (int i = 0; i < 3; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(7f);

            // Spawn 1 lengendary target
            SpawnLegendary();
        }

        yield return new WaitForSeconds(5f);
        Debug.Log("Coroutines done!!");
        coroutinesFinished = true;
    }

    private void SpawnCommon()
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(commonTarget, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnUncommon()
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(uncommonTarget, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnRare()
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(rareTarget, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnLegendary()
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(legendaryTarget, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }
}
