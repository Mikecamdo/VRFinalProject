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
                    case "100 Target":    
                        newScore = currentScore + 100;
                        break;

                    case "Uncommon Target":
                    case "500 Target":
                        newScore = currentScore + 500;
                        break;

                    case "Rare Target":
                    case "1000 Target":
                        newScore = currentScore + 1000;
                        break;

                    case "Legendary Target":
                    case "5000 Target":
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
        Destroy(transform.parent.gameObject);
        Destroy(gameObject); // destroy the target
    }
}
