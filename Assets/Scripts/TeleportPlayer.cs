using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerToLocation : MonoBehaviour
{
    public Transform destinationObject;

    private void Start()
    {
        
    }
    void Update()
    {
       
            TeleportPlayer();
       
    }

    void TeleportPlayer()
    {
        // Check if the destination object is assigned
        if (destinationObject != null)
        {
            // Set the player's position to the destination object's position on X and Z axes
            Vector3 destinationPosition = new Vector3(destinationObject.position.x, transform.position.y, destinationObject.position.z);
            transform.position = destinationPosition;

            // Set the player's rotation to match the destination object's rotation
            transform.rotation = destinationObject.rotation;
        }
        else
        {
            Debug.LogError("Destination object not assigned!");
        }
    }
}
