using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class FootprintSounds : MonoBehaviour
{
    [System.Serializable]
    public class TagFootstepSounds
    {
        public string tag;
        public AudioClip[] footstepSounds;
    }

    public TagFootstepSounds[] tagFootstepSounds; // Array of footstep sound clips for different tags
    public float walkingFootstepInterval = 0.5f; // Time interval between footstep sounds when walking
    public float runningFootstepInterval = 0.3f; // Time interval between footstep sounds when running

    private AudioSource audioSource;
    private float currentFootstepInterval;
    private float nextFootstepTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentFootstepInterval = walkingFootstepInterval;
        nextFootstepTime = 0f;
    }

    void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Update footstep interval based on the player's movement
        currentFootstepInterval = isRunning ? runningFootstepInterval : walkingFootstepInterval;

        // Play footstep sounds at intervals when the player is moving on the ground
        if (IsPlayerMoving() && Time.time >= nextFootstepTime)
        {
            PlayFootstepSound();
            nextFootstepTime = Time.time + currentFootstepInterval;
        }
    }

    void PlayFootstepSound()
    {
        // Perform a raycast downwards from the player's position to detect the ground or surface
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            string tag = hit.collider.tag;

            // Find the footstep sounds for the current tag
            foreach (var tagFootstepSound in tagFootstepSounds)
            {
                if (tagFootstepSound.tag == tag)
                {
                    // Play a random footstep sound for the current tag
                    AudioClip[] footstepSounds = tagFootstepSound.footstepSounds;
                    if (footstepSounds != null && footstepSounds.Length > 0)
                    {
                        int randomIndex = Random.Range(0, footstepSounds.Length);
                        audioSource.clip = footstepSounds[randomIndex];
                        audioSource.Play();
                    }
                    return;
                }
            }
        }
    }

    bool IsPlayerMoving()
    {
        // Check if the player is moving using input axes
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f;
    }
}