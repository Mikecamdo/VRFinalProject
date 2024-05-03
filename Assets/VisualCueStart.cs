using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualCueStart : MonoBehaviour
{
    public int version = 1;

    private void OnCollisionEnter(Collision collision)
    {
        TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();
        TextMeshPro dummyScore = GameObject.FindGameObjectWithTag("dummyScore").GetComponent<TextMeshPro>();

        dummyScore.text = "Score: " + "\n";
        if (scoreText != null)
        {
            scoreText.text = "0";
        }

        SpawnerScript spawnerScript = GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>();
        spawnerScript.StartGame(version);

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}