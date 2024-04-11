using UnityEngine;

public class HitTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // destroy the target
    }
}
