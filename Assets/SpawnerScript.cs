using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject commonTarget;
    public GameObject uncommonTarget;
    public GameObject rareTarget;
    public GameObject legendaryTarget;

    public GameObject _100Target;
    public GameObject _500Target;
    public GameObject _1000Target;
    public GameObject _5000Target;

    public bool coroutinesFinished = false;

    public int targetsDestroyed = 0;

    public void StartGame(int version)
    {
        // Start the spawning coroutine
        if (version == 1) // Color Cues
        {
            StartCoroutine(SpawnCommonTargets(commonTarget));
            StartCoroutine(SpawnUncommonTargets(uncommonTarget));
            StartCoroutine(SpawnRareTargets(rareTarget));
            StartCoroutine(SpawnLegendaryTargets(legendaryTarget));
        }
        else // version == 2, Number Cues
        {
            StartCoroutine(SpawnCommonTargets(_100Target));
            StartCoroutine(SpawnUncommonTargets(_500Target));
            StartCoroutine(SpawnRareTargets(_1000Target));
            StartCoroutine(SpawnLegendaryTargets(_5000Target));
        }
        
    }

    private IEnumerator SpawnCommonTargets(GameObject target)
    {
        // Loop through the number of spawns
        for (int i = 0; i < 10; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(2f);

            // Spawn 5 common targets
            SpawnCommon(target);
            SpawnCommon(target);
            SpawnCommon(target);
            SpawnCommon(target);
            SpawnCommon(target);
        }
    }

    private IEnumerator SpawnUncommonTargets(GameObject target)
    {
        // Loop through the number of spawns
        for (int i = 0; i < 7; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(3f);

            // Spawn 3 uncommon targets
            SpawnUncommon(target);
            SpawnUncommon(target);
            SpawnUncommon(target);
        }
    }

    private IEnumerator SpawnRareTargets(GameObject target)
    {
        // Loop through the number of spawns
        for (int i = 0; i < 5; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(4f);

            // Spawn 2 rare targets
            SpawnRare(target);
            SpawnRare(target);
        }
    }

    private IEnumerator SpawnLegendaryTargets(GameObject target)
    {
        // Loop through the number of spawns
        for (int i = 0; i < 3; i++)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(7f);

            // Spawn 1 lengendary target
            SpawnLegendary(target);
        }

        yield return new WaitForSeconds(7f);
        Debug.Log("Coroutines done!!");
        coroutinesFinished = true;
    }

    private void SpawnCommon(GameObject targetToSpawn)
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(targetToSpawn, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnUncommon(GameObject targetToSpawn)
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(targetToSpawn, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnRare(GameObject targetToSpawn)
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(targetToSpawn, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }

    private void SpawnLegendary(GameObject targetToSpawn)
    {
        // Define the position where you want to spawn the object
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), Random.Range(0.5f, 2.5f), Random.Range(-1f, -3f));

        // Instantiate the object at the specified position
        GameObject target = Instantiate(targetToSpawn, spawnPosition, Quaternion.identity);

        SelfDestructScript selfDestructScript = target.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
    }
}
