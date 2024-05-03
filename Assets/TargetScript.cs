using UnityEngine;
using TMPro;

public class TargetScript : MonoBehaviour
{
    private TextMeshPro scoreText; // Reference to the TextMeshPro component   
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindGameObjectWithTag("Setup").GetComponent<SpawnerScript>().targetsDestroyed++;

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
                int newScore;
                switch(gameObject.name)
                {
                    default:
                    case "Common Target":
                        newScore = currentScore + 100;
                        break;

                    case "Uncommon Target":
                        newScore = currentScore + 500;
                        break;

                    case "Rare Target":
                        newScore = currentScore + 1000;
                        break;

                    case "Legendary Target":
                        newScore = currentScore + 5000;
                        break;
                }

                
                scoreText.text = newScore.ToString(); // Update score text
            }
            else
            {
                Debug.LogError("Failed to parse current score: " + scoreText.text);
            }
        }
        Destroy(collision.gameObject);
        Destroy(gameObject); // destroy the target
    }
}
