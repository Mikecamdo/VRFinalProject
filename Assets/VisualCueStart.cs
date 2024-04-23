using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualCueStart : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();

        if (scoreText != null)
        {
            scoreText.text = "0";
        }

        SpawnerScript spawnerScript = GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>();
        spawnerScript.StartGame();

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
