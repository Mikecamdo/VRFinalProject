using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TARGET HIT!!");
        Destroy(collision.gameObject);
        Destroy(gameObject); // destroy the target
    }
}
