using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

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
            TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();

            if (scoreText != null)
            {
                int.TryParse(scoreText.text, out finalScore);
            }

            // Write final score to CSV
            WriteScoreToCSV(finalScore);

            // Instantiate start target
            Instantiate(startTarget, new Vector3(0, 0, 0), Quaternion.identity);

            // Display final score
            TextMeshPro textFinalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<TextMeshPro>();
            textFinalScore.text = "Final Score: " + finalScore.ToString();
            TextMeshPro textNewScore = Instantiate(textFinalScore, new Vector3(-4, 1, 0), Quaternion.Euler(0, 180, 0));


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
        string filePath = Application.persistentDataPath + "/Finalscores.csv";

        // Check if the file exists, if not create it and write headers
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {

                writer.WriteLine("Player Name, Score, Target Accuracy");
            }
        }

        // Append score to the file
        using (StreamWriter writer = File.AppendText(filePath))
        {
            Debug.Log("Write Score"); 
            writer.WriteLine("Player," + score + "," + Math.Round((GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>().targetsDestroyed / 84.0) * 100, 2));
            Debug.Log("Accuracy:");
            Debug.Log(GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>().targetsDestroyed / 84.0);

        }
    }
}
