using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SimpleOpenClose : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;

    [SerializeField] private bool objectInteractable = false;

    [SerializeField] private bool isOpen;

    private void Start()
    {
     

        if (myAnimator == null)
        {
            Debug.LogError("Animator is not found on this GameObject.");
        }
    }

    private void Update()
    {
        if (objectInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                // Player is close and pressed E, open the door
                OpenDoor();
            }
            if (!isOpen)
            {
                CloseDoor();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger zone, set objectOpen to true
            objectInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger zone, set objectOpen to false
            objectInteractable = false;
        }
    }

    private void OpenDoor()
    {
        if (myAnimator != null)
        {
            myAnimator.Play("Open");
            Debug.Log("Opening the door.");
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }
    }

    private void CloseDoor()
    {
        if (myAnimator != null)
        {
            myAnimator.Play("Close");
            Debug.Log("Closing the door.");
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }
    }
}