using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 90f; // Speed at which the door rotates
    public float openAngle = 90f; // Angle to which the door opens
    public bool isOpen = false; // Flag to track whether the door is open
    public Transform player; // Reference to the player's transform
    public float interactionDistance = 3f; // Distance at which the player can interact with the door
    public AudioClip openSound; // Sound clip for opening the door
    public AudioClip closeSound; // Sound clip for closing the door

    private Quaternion initialRotation; // Initial rotation of the door
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation of the door
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the door
    }

    // Update is called once per frame
    void Update()
    {
        // Check for user input to interact with the door
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cast a ray from the player's position forward
            RaycastHit hit;
            if (Physics.Raycast(player.position, player.forward, out hit, interactionDistance))
            {
                // Check if the ray hit the door
                if (hit.collider.gameObject == gameObject)
                {
                    if (isOpen)
                    {
                        CloseDoor();
                    }
                    else
                    {
                        OpenDoor();
                    }
                }
            }
        }
    }

    // Method to open the door
    void OpenDoor()
    {
        Quaternion targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * openAngle); // Calculate the target rotation
        StartCoroutine(RotateDoor(targetRotation)); // Start coroutine to rotate the door
        isOpen = true; // Update flag
        PlaySound(openSound); // Play the opening sound
    }

    // Method to close the door
    void CloseDoor()
    {
        Quaternion targetRotation = initialRotation; // Return to the initial rotation
        StartCoroutine(RotateDoor(targetRotation)); // Start coroutine to rotate the door
        isOpen = false; // Update flag
        PlaySound(closeSound); // Play the closing sound
    }

    // Coroutine to rotate the door smoothly
    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // Method to play a sound clip
    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}