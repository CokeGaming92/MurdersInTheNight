using UnityEngine;

public class ZoomController : MonoBehaviour
{
   
    public float zoomSpeed = 1f; // Adjust this value to control the speed of zooming
    public float minFOV = 20f; // Minimum FOV
    public float maxFOV = 60f; // Maximum FOV

    public bool isZooming;
    private float originalFOV;

    void Start()
    {
        isZooming = false;
        // Save the original FOV of the camera
        originalFOV = maxFOV;
    }

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            Camera.main.fieldOfView = minFOV;
          // Set isZooming to true to indicate that zooming is in progress
          isZooming = true;
        }

        // Check if the right mouse button is released
        if (Input.GetMouseButtonUp(1))
        {
            // Reset the FOV to its original value
            Camera.main.fieldOfView = originalFOV;

            // Set isZooming to false to indicate that zooming is complete
            isZooming = false;
        }

    
    }
}