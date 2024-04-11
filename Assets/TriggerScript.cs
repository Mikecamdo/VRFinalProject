using UnityEngine;
using UnityEngine.InputSystem; // Import Unity's Input System namespace

public class TriggerScript : MonoBehaviour
{
    // Define a reference to the input action asset
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

            // Add your custom behavior here
            // For example, you can shoot a gun, grab an object, etc.
        }
    }
}
