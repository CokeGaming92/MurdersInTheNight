using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilDawnLikeCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 2.0f;
    public float smoothRotationSpeed = 5.0f;

    private void Update()
    {
        HandleInput();
        CheckPlayerVisibility();
    }

    private void HandleInput()
    {
        // Handle player input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Rotate the player based on input
        playerTransform.Rotate(Vector3.up * mouseX);

        // Rotate the camera to look at the player
        Vector3 playerPos = playerTransform.position;
        playerPos.y = transform.position.y; // Keep the same height
        transform.LookAt(playerPos);
    }

    private void CheckPlayerVisibility()
    {
        // Check if player is not visible by any camera
        if (!IsPlayerVisible())
        {
            // Smoothly rotate the camera towards the player's lookAt position
            Vector3 playerPos = playerTransform.position;
            playerPos.y = transform.position.y; // Keep the same height
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothRotationSpeed);
        }
    }

    private bool IsPlayerVisible()
    {
        // Implement your logic to check if the player is visible by any camera
        // You can use raycasting, culling, or other techniques
        // For simplicity, always return true for now
        return true;
    }
}