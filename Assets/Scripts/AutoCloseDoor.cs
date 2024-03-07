using UnityEngine;

public class AutoCloseDoor : MonoBehaviour
{
    public float detectionDistance = 5f;  // Adjust this distance according to your needs
    public Transform player;               // Drag and drop the player GameObject into this field
    public Animator doorAnimator;          // Drag and drop the door Animator into this field
    public Interactable interactable;
   
    private void Start()
    {
     
    }

    private void Update()
    {
        if (interactable.isInteracted)
        {
            // Check the distance between the door and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the player is within the detection distance and the door is not already open, close the door
            if (distanceToPlayer > detectionDistance)
            {
                CloseDoor();
            }
        }
    }

    public void CloseDoor()
    {
        // Trigger the "Close" animation in the Animator
        doorAnimator.Play("Close");
        interactable.isInteracted = false;  

    }
}