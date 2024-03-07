using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // Assign the player's transform reference in the Unity Editor
    public float rotationSpeed = 5f;
    public float movementSpeed = 3f;
    
    public float detectionDistance = 10f; // Adjust this distance as needed
    public float attackDistance = 2f;
    //Handle Enemy Health
    public int maxHealth = 100;
   [SerializeField] private int currentHealth;

    public Animator animator;
    private bool isPlayerDetected = false;
    public AudioSource chaseMusic, breathing;
    private bool hasPlayedChaseMusic = false;
    public CharacterController characterController;
    public NavMeshAgent navMeshAgent;
    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
        if(currentHealth > 0)
        {
            if (player != null)
            {
               if(Vector3.Distance(transform.position, player.position) >= attackDistance)
                {
                    // Check if the player is within the detection distance before moving
                    if (Vector3.Distance(transform.position, player.position) <= detectionDistance)
                    {
                        
                        isPlayerDetected = true;
                        MoveTowardsPlayer();
                        RotateTowardsPlayer();
                        // Play walking animation
                        if (animator != null)
                        {
                            animator.Play("Walking");
                        }


                        navMeshAgent.isStopped = false;


                        // Play chase music
                        if (chaseMusic != null && !hasPlayedChaseMusic)
                        {

                            chaseMusic.enabled = true;
                            hasPlayedChaseMusic = true;
                        }

                        // Update the destination to the player's position
                        if (navMeshAgent != null)
                        {
                            navMeshAgent.SetDestination(player.position);
                        }
                    }
                    else
                    {
                        isPlayerDetected = false;

                        // Stop walking animation
                        if (animator != null)
                        {
                            animator.Play("Idle");
                        }
                        navMeshAgent.isStopped = true;
                        // Stop chase music
                        if (chaseMusic != null && hasPlayedChaseMusic)
                        {
                            chaseMusic.enabled = false;
                            hasPlayedChaseMusic = false;
                        }
                    }
                }
               
               

                if (Vector3.Distance(transform.position, player.position) <= attackDistance)
                {
                    // Play attack animation when the player is near
                    if (animator != null)
                    {
                        animator.Play("Attack");
                        MoveTowardsPlayer();
                        RotateTowardsPlayer();
                    }
                }
            }
        }
       
    }

    void RotateTowardsPlayer()
    {
        // Get the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; // Locking on the y-axis

        // Calculate the rotation to face the player
        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        // Get the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Normalize the direction to get a unit vector
        directionToPlayer.Normalize();

        // Move towards the player using CharacterController
        if (characterController != null)
        {
            characterController.SimpleMove(directionToPlayer * movementSpeed);
        }
    }

    // Add a method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Optionally, you can add effects, such as flashing or sound, when the enemy takes damage.

        if (currentHealth <= 0)
        {
            Die();
        }


    }

    void Die()
    {
        // Perform actions when the enemy dies
        // For example: play death animation, stop movement, etc.

        animator.Play("Death");
        // Stop chase music
        if (chaseMusic != null && hasPlayedChaseMusic)
        {
            chaseMusic.enabled = false;
            hasPlayedChaseMusic = false;
        }

        breathing.volume--;
        if(breathing.volume == 0)
        {
            breathing.volume = 0;
        }

        // Set a timer to revive the enemy after 5 seconds
        Invoke("Revive", 5f);
    }

    void Revive()
    {
        // Perform actions to revive the enemy
        // For example: play revive animation, reset health, etc.

       

        // You may need additional logic here depending on your game requirements

        // Play "GetBackUp" animation
        if (animator != null)
        {
            animator.CrossFade("GettingBackUp", 0.37F); // Adjust the duration as needed
        }

        // Reset other variables or states as needed
        // ...

        // Start a coroutine to transition to "Idle" after the "GetBackUp" animation
        StartCoroutine(TransitionToIdleAfterDelay(3.19f)); // Adjust the delay as needed
    }

    IEnumerator TransitionToIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

       
           
            currentHealth = maxHealth;
        breathing.volume = 100;

        // Any additional actions or logic after transitioning to "Idle"
        // ...
    }
}