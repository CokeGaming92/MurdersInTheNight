using Unity.VisualScripting;
using UnityEngine;

public class RaycastCamera : MonoBehaviour
{
    public float interactDistance = 2f; // Max distance to interact with objects
    private Camera cam;
    public bool isOpen = false; // Flag to track whether the door is open
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // Cast a ray from the center of the camera's viewport
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Check if the hit object has a DoorController component
            DoorController door = hit.collider.GetComponent<DoorController>();
            if (door != null)
            {
                // Open or close the door when the player presses a button (e.g., "E")
                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    isOpen = !isOpen;

                    if (isOpen) // Add appropriate condition to check if door is closed
                    {
                        door.OpenDoor();
                    }
                    else
                    {
                        door.CloseDoor();
                    }
                }
            }
        }
    }
}