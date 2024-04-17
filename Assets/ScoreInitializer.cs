using TMPro;
using UnityEngine;

public class ScoreInitializer : MonoBehaviour
{
    private void Start()
    {
        // Find the TextMeshPro component with the tag "Score"
        TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();
        if (scoreText != null)
        {
            // Initialize score to zero if it hasn't been initialized yet
            if (string.IsNullOrEmpty(scoreText.text) || scoreText.text == "0")
            {
                scoreText.text = "0";
            }
        }
        else
        {
            Debug.LogError("TextMeshPro component with the tag 'Score' not found.");
        }
    }
}
