using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class FinalScoreBoard : MonoBehaviour
{
    GameObject startTargets;
    SpawnerScript spawnerScript;
    int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>();
        startTargets = GameObject.FindGameObjectWithTag("StartPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.coroutinesFinished)
        {
            TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();

            if (scoreText != null)
            {
                int.TryParse(scoreText.text, out finalScore);
            }

            // Write final score to CSV
            WriteScoreToCSV(finalScore);

            // Instantiate start target
            startTargets.transform.position = new Vector3(-0.2f, 1.75f, 1.14f);

            // Display final score
            TextMeshPro textFinalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<TextMeshPro>();
            textFinalScore.text = "Final Score: " + finalScore.ToString();
            textFinalScore.transform.position = new Vector3(-4f, 1.3f, 0f);

            // Reset coroutinesFinished flag
            spawnerScript.coroutinesFinished = false;

            // Clear score texts
            TextMeshPro newScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();
            newScoreText.text = "";
            TextMeshPro dummyScore = GameObject.FindGameObjectWithTag("dummyScore").GetComponent<TextMeshPro>();
            dummyScore.text = "";
        }
    }

    // Function to write final score to CSV
    void WriteScoreToCSV(int score)
    {
        Debug.Log("Writing to csv");
        string filePath = Application.persistentDataPath + "/scores.csv";

        // Check if the file exists, if not create it and write headers
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {

                writer.WriteLine("Player Name, Score");
            }
        }

        // Append score to the file
        using (StreamWriter writer = File.AppendText(filePath))
        {
            Debug.Log("Write Score"); 
            writer.WriteLine("Player," + score);
        }
    }
}
