// TargetScript.cs
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public void DestroyTarget()
    {
        // Perform any actions you want when the target is destroyed
        Destroy(gameObject); // Destroy the target
    }
}
