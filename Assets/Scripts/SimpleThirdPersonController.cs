using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleThirdPersonController : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float idleRotationSpeed = 50.0f;
    public float gravity = 9.8f;
    public bool isGunEquipped;
    private CharacterController characterController;
    private Transform mainCameraTransform;
     public Animator animator;
    private Vector3 velocity;
    [SerializeField] private float currentSpeed;
    public bool isRun = false;
    public bool isOpeningDoor = false;
    public bool inFrontOfDoor = false;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
    }
 
    private void Update()
    {
        
        
            HandleMovementInput();
            HandleRotationInput();
            // Correct the initial rotation to face forward
            CorrectInitialRotation();
       
        
       
       
        UpdateAnimatorParameters();
        ApplyGravity();
        // Handle other character movements, inputs, etc.

        if (inFrontOfDoor)
        {
            OpenDoor();
        }
     


    }

    

    void CorrectInitialRotation()
    {
        // Calculate the rotation needed to face forward (adjust as needed)
        Quaternion desiredRotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);

        // Apply the correction to the NPC's rotation
        transform.rotation = desiredRotation;
    }


    private void HandleMovementInput()
    {
       if(!isRun)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");





            Vector3 forward = mainCameraTransform.forward;
            Vector3 right = mainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();


           
            // Determine the speed based on whether the player is running or walking
            float speed = walkSpeed;

            Vector3 moveDirection = forward * verticalInput + right * horizontalInput;
            Vector3 moveVector = moveDirection.normalized * speed;
            moveVector.y += velocity.y;

            // Update currentSpeed for animator
            currentSpeed = moveDirection.magnitude > 0 ? moveVector.magnitude : 0;

            // Rotate the player to face the movement direction when moving
            if (moveDirection != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed * Time.deltaTime);
            }

            characterController.Move(moveVector * Time.deltaTime);
        }

        if (isRun)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");





            Vector3 forward = mainCameraTransform.forward;
            Vector3 right = mainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();


            // Check if left shift is pressed
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            // Determine the speed based on whether the player is running or walking
            float speed = isRunning ? runSpeed : walkSpeed;

            Vector3 moveDirection = forward * verticalInput + right * horizontalInput;
            Vector3 moveVector = moveDirection.normalized * speed;
            moveVector.y += velocity.y;

            // Update currentSpeed for animator
            currentSpeed = moveDirection.magnitude > 0 ? moveVector.magnitude : 0;

            // Rotate the player to face the movement direction when moving
            if (moveDirection != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed * Time.deltaTime);
            }

            characterController.Move(moveVector * Time.deltaTime);
        }
    }

    private void HandleRotationInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        RotatePlayerWithInput(horizontalInput);
    }

    private void RotatePlayerWithInput(float horizontalInput)
    {
        // Rotate the player based on horizontal input
        // You can customize this part based on your requirements
        transform.Rotate(Vector3.up * rotationSpeed * horizontalInput * Time.deltaTime);
    }

 
    private void UpdateAnimatorParameters()
    {
        // Set Animator parameters based on currentSpeed for movement
        animator.SetFloat("x", currentSpeed);
        animator.SetFloat("y", currentSpeed);
        // Add additional logic to differentiate between horizontal and vertical movement if needed
    }
    public void RunningAble()
    {
        isRun = true;
        
    }
    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            // Reset velocity when grounded
            velocity.y = -0.5f;
        }
    }


    public void WhileInTriggerCutscene()
    {
        currentSpeed = 0f;
    }

    public void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpeningDoor = true;
            StartCoroutine(OpenDoorCoroutine());
        }

    }

    public void IsInFrontOfDoor()
    {
        inFrontOfDoor = true;
    }

    public void IsAwayFromDoor()
    {
        inFrontOfDoor = false;
    }
    private IEnumerator OpenDoorCoroutine()
    {
        if (isOpeningDoor)
        {
            animator.Play("openDoor");
            yield return new WaitForSeconds(1.2f); // Wait for the animation to complete
            isOpeningDoor = false;
        }

        if (!isOpeningDoor)
        {
            animator.Play("Blend Tree");
        }
    }

    public void SetWalkSpeed()
    {
        walkSpeed = 2f;
    }
}