using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyFootprintSounds : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array of footstep sound clips
    public float walkingFootstepInterval = 0.5f; // Time interval between footstep sounds when walking
    public float runningFootstepInterval = 0.2f; // Time interval between footstep sounds when running

    private AudioSource audioSource;
    private float currentFootstepInterval;
    private float nextFootstepTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentFootstepInterval = walkingFootstepInterval;
        nextFootstepTime = 0f;
    }

    // Assume the enemy's movement is controlled by its own system,
    // and you update the isRunning variable accordingly.

    void Update()
    {
        // Example: Determine if the enemy is running based on its own logic
        bool isRunning = IsEnemyRunning();

        // Update footstep interval based on the enemy's movement
        currentFootstepInterval = isRunning ? runningFootstepInterval : walkingFootstepInterval;

        // Play footstep sounds at intervals when the enemy is moving on the ground
        if (IsEnemyMoving() && Time.time >= nextFootstepTime)
        {
            PlayFootstepSound();
            nextFootstepTime = Time.time + currentFootstepInterval;
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSounds != null && footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
        }
    }

    bool IsEnemyMoving()
    {
        // Implement your logic to check if the enemy is moving
        // This could involve checking its own movement system
        // For simplicity, always return true for now
        return true;
    }

    bool IsEnemyRunning()
    {
        // Implement your logic to check if the enemy is running
        // This could involve checking its own running state
        // For simplicity, always return false for now (walking)
        return false;
    }
}