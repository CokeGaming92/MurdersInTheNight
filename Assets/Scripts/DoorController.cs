using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
   


    public AudioClip openSound; // Sound clip for opening the door
    public AudioClip closeSound; // Sound clip for closing the door


    private AudioSource audioSource; // Reference to the AudioSource component
    public Animator animator;



   
    void Start()
    {
       
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the door

      
       
    }





    // Method to open the door
    public void OpenDoor()
    {
        animator.Play("door_open");
        
        PlaySound(openSound); // Play the opening sound
    }

    // Method to close the door
    public void CloseDoor()
    {
        animator.Play("door_close");
        
        PlaySound(closeSound); // Play the closing sound
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