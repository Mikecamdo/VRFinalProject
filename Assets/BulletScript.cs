// BulletScript.cs
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
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
