// TargetScript.cs
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Make the method public so it can be called from other scripts
    public void DestroyTarget()
    {
        // Perform any actions you want when the target is destroyed
        Destroy(gameObject); // Destroy the target
    }

    // This method is called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Call the DestroyTarget method to destroy the target
            DestroyTarget();
        }
    }
}
