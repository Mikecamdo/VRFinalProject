using UnityEngine;

public class HitTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // destroy the target
    }
}
