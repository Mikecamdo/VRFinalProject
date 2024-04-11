using UnityEngine;

public class HitTargetScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy the target
    }
}
