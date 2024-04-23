using UnityEngine;

public class DestroyInitialTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the initial target tagged as "Start"
        if (collision.gameObject)
        {
            Debug.Log("Initial target destroyed");

            // Destroy the initial target object
            Destroy(collision.gameObject);

            // Set initial target destroyed flag to true
            // Start spawning coroutine
        }
        else
        {
            // Handle collisions with subsequent targets if needed
            // For example, update score text or handle other interactions
        }
    }
}
