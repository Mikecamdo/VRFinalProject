using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic; 


public class ShootSystem: MonoBehaviour
{
    public GameObject Revolver_Bullet;
    public Transform muzzlePoint;
    public float bulletSpeed = 1f;
    public AudioClip shootSound;
    public AudioSource audioSource;

    public InputActionReference triggerAction;

    private Vector3 controllerPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controllerPosition = transform.position;
    }

    void Update()
    {
        controllerPosition = transform.position;
    }

    // Define a method to handle the trigger pull event
    private void OnEnable()
    {
        // Enable the input action
        triggerAction.action.Enable();

        // Subscribe to the trigger pull event
        triggerAction.action.performed += OnTriggerPull;
    }

    private void OnDisable()
    {
        // Disable the input action
        triggerAction.action.Disable();

        // Unsubscribe from the trigger pull event
        triggerAction.action.performed -= OnTriggerPull;
    }

    // Method to handle trigger pull event
    private void OnTriggerPull(InputAction.CallbackContext context)
    {

        // Trigger action when the trigger is pulled
        Shoot(); 
    
    }

    void Shoot()
    {
        audioSource.clip = shootSound;
        audioSource.Play(); 

        GameObject bullet = Instantiate(Revolver_Bullet, controllerPosition, transform.rotation);

        SelfDestructScript selfDestructScript = bullet.GetComponent<SelfDestructScript>();

        if (selfDestructScript != null)
        {
            selfDestructScript.destroySelf = true;
        }
        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = muzzlePoint.forward * bulletSpeed;
        }
    }
}
