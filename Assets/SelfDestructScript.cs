using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{
    public float destructionDelay = 5f;
    public bool destroySelf = false;

    void Start()
    {
        if (destroySelf)
        {
            Invoke("DestroySelf", destructionDelay);
        } 
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}