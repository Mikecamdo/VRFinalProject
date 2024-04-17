using UnityEngine;
using TMPro;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 10; // Score value for each destroyed object

    private TextMeshPro scoreText; // Reference to the TextMeshPro component

    

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject); // Destroy the collider object
        Destroy(gameObject); // Destroy the target object

        // Update score text
        TextMeshPro scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>();

        if (scoreText != null)
        {
            int currentScore;
            if (int.TryParse(scoreText.text, out currentScore))
            {
                // Parsing successful, proceed with updating the score
                int newScore = currentScore + scoreValue;
                scoreText.text = newScore.ToString(); // Update score text
            }
            else
            {
                // Parsing failed, handle the error (e.g., log a message)
                Debug.LogError("Failed to parse current score: " + scoreText.text);
                // Set the score to zero
                //scoreText.text = "0";
            }
        }
        Debug.Log("TARGET HIT!!");
        Destroy(collision.gameObject);
        Destroy(gameObject); // destroy the target
    }
}
