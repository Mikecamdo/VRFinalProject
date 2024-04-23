using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreBoard : MonoBehaviour
{
    public GameObject startTarget;
    SpawnerScript spawnerScript;
    int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.coroutinesFinished)
        {
            Debug.Log("Inside loop");
            TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();

            if (scoreText != null)
            {
                int.TryParse(scoreText.text, out finalScore);
            }

            //TODO: Display final score

            GameObject startOver = Instantiate(startTarget, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Spawned New Target!!");

            spawnerScript.coroutinesFinished = false;
        }
    }
}
