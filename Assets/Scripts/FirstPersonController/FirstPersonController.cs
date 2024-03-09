using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 3f;
    public float runningSpeed = 7f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;


    CharacterController characterController;
    public Animator animator;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    bool canRun = false;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = 0;
        float curSpeedY = 0;
        if (!canRun)
        {
            curSpeedX = canMove ? walkingSpeed * Input.GetAxis("Vertical") : 0;
            curSpeedY = canMove ? walkingSpeed * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
          
        }

        if (canRun)
        {
            // Calculate speed based on whether the player is running or walking
             curSpeedX = canMove ? (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
             curSpeedY = canMove ? (Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            // Update animator
          
        }

        // Apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

       

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Update animator parameters
        UpdateAnimator(curSpeedX, curSpeedY);
    }


    // Method to update the animator based on movement speed
    // Method to update the animator based on movement speed
    // Method to update the animator based on movement speed
    void UpdateAnimator(float speedX, float speedY)
    {
        float moveSpeed = Mathf.Abs(speedX) + Mathf.Abs(speedY); // Total movement speed

        // Set animation states based on speed
        if (moveSpeed > 0)
        {
            if (canRun && Input.GetKey(KeyCode.LeftShift))
            {
                animator.Play("running");
            }
            else
            {
                animator.Play("walking");
            }
        }
        else
        {
            animator.Play("idle");
        }
    }

    public void CanRun()
    {
        canRun = true;
    }

}