using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractable : MonoBehaviour
{
    public float interactionRange = 3f;
    public LayerMask interactableLayer;

    private Camera mainCamera;

    void Start()
    {
        // Assuming the main camera is tagged as "MainCamera"
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Cast a ray from the main camera's position forward
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits an object within the specified range and on the interactable layer
        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            // Check if the object has a collider
            if (hit.collider != null)
            {
               
            }
        }
    }
}
