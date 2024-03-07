using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suburb
{

    [RequireComponent(typeof(CharacterController))]

    public class SimplePlayerController : MonoBehaviour
    {
        public Camera playerCamera;
        public float walkSpeed = 1.15f;
        public float runSpeed = 4.0f;
        public float lookSpeed = 2.0f;
        public float lookXLimit = 60.0f;
        public float gravity = 150.0f;

        CharacterController characterController;

        [SerializeField]  private GameObject currentPhantom; // Reference to the currently instantiated phantom

 

        public GameObject trapPrefab; // Assign the Trap prefab in the Inspector
        public GameObject trapContainer; // Assign an empty GameObject in the Inspector to act as the trap container

        public float normalHeight, crouchHeight;

        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;
        private bool canMove = true;

        void Start()
        {
            characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }

        void Update()
        {

            if(Input.GetKeyDown(KeyCode.C))
            {
                characterController.height = crouchHeight;
                walkSpeed = 1f;
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                characterController.height = normalHeight;
                walkSpeed = 2f;
            }
            // Check for player input to place a trap
            if (Input.GetKeyDown(KeyCode.T))
            {
                PlaceTrap();
            }
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

        void PlaceTrap()
        {

           
            if (trapContainer == null)
            {
                trapContainer = new GameObject("TrapContainer");
            }


            if (currentPhantom != null)
            {
                // Specify the position where you want to instantiate the trap (adjust as needed)
                Vector3 trapPosition = transform.position + transform.forward * 2.0f;

                // Instantiate the trap at the player's position (you might want to adjust the placement position)
                GameObject trapInstance = Instantiate(trapPrefab, trapPosition, Quaternion.identity);

                trapInstance.transform.parent = trapContainer.transform;
               
               
    
            }
            

            

        }
    }
}