using UnityEngine;
using UnityEngine.Events;

public enum InteractableObjectType
{
    Microwave,
    Chair,
    Phone,
    Door
}

public class InteractableObject : MonoBehaviour
{
    public float interactionDistance = 3f; // Set the interaction distance
    public InteractableObjectType interactableType; // Specify the type of interactable object
    public UnityEvent onInteract; // UnityEvent to invoke when interacting with the object


    public void Start()
    {
        
    }
    // This method will be called when the object is interacted with
    public virtual void Interact()
    {
        switch (interactableType)
        {
            case InteractableObjectType.Microwave:
                Debug.Log("Interacting with Microwave...");
                // Implement interaction logic for Microwave
                onInteract.Invoke();
                break;
            case InteractableObjectType.Chair:
                Debug.Log("Interacting with Chair...");
                // Implement interaction logic for Oven
                onInteract.Invoke();
                break;
            case InteractableObjectType.Phone:
                Debug.Log("Interacting with Phone...");
                // Implement interaction logic for Phone
                break;
            case InteractableObjectType.Door:
                Debug.Log("Interacting with Door...");
                // Implement interaction logic for Door
                onInteract.Invoke();
                break;
            default:
                Debug.LogWarning("Unknown interactable object type: " + interactableType);
                break;
        }
    }
}