using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Print a message to the console when the bullet collides with any object
        Debug.Log("Bullet collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Target"))
        {
            TargetScript target = collision.gameObject.GetComponent<TargetScript>();

            if (target != null)
            {
                target.DestroyTarget();
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
