using UnityEngine;
using UnityEngine.InputSystem;
public class shootSystem: MonoBehaviour
{
    public GameObject Revolver_Bullet;
    //public GameObject Revolver_Bullet;
    public Transform muzzlePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    private float nextFireTime;

    public InputActionReference triggerAction;

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
        // Check if the trigger is pressed
        if (context.ReadValue<float>() > 0.5f)
        {
            // Trigger action when the trigger is pulled
            Debug.Log("Trigger pulled on right controller!");
            Shoot(); 

            // Add your custom behavior here
            // For example, you can shoot a gun, grab an object, etc.
        }
    }

    //void Update()
    //{
      //  if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        //{
          //  Shoot();
            //nextFireTime = Time.time + fireRate;
        //}
    //}

    void Shoot()
    {
        GameObject bullet = Instantiate(Revolver_Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = muzzlePoint.forward * bulletSpeed;
        }
        // You can add additional logic here such as bullet damage, effects, etc.
    }
}