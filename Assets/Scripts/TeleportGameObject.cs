using UnityEngine;

public class TeleportGameObject : MonoBehaviour
{
    public Transform targetPosition; // The target position to teleport to
    public Transform targetRotation; // The target rotation to set after teleportation

    void Start()
    {

    }

    void Update()
    {
        Teleport();
    }
    void Teleport()
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition.position; // Teleport to the target position
        }
        else
        {
            Debug.LogWarning("Target position is not assigned!");
            return;
        }

        if (targetRotation != null)
        {
            transform.rotation = targetRotation.rotation; // Set the rotation to the target rotation
        }
        else
        {
            Debug.LogWarning("Target rotation is not assigned!");
        }
    }

    // Example usage: Call Teleport() method wherever you need to teleport the object.
    // You can call this method in response to a trigger, button press, etc.
}