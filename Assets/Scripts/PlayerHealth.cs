using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100; // Maximum health of the player
    public float currentHealth;    // Current health of the player
    public GameObject health_okay, health_bad, health_worst;
    public GameObject Player;
    public UnityEvent KillPlayer;
    void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health
    }

    // Function to handle damage to the player
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount * Time.deltaTime;

        // Check if the player has run out of health
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if(currentHealth <= 70)
        {
            Player.GetComponent<SimpleThirdPersonController>().walkSpeed = 1;
            Player.GetComponent<SimpleThirdPersonController>().runSpeed = 2;
            health_okay.SetActive(true);
        }
        if (currentHealth <= 50)
        {
            Player.GetComponent<SimpleThirdPersonController>().walkSpeed = .5f;
            Player.GetComponent<SimpleThirdPersonController>().runSpeed = 1f;
            health_bad.SetActive(true);
            health_okay.SetActive(false);
        }
        if (currentHealth <= 20)
        {
            Player.GetComponent<SimpleThirdPersonController>().walkSpeed = .2f;
            Player.GetComponent<SimpleThirdPersonController>().runSpeed = .4f;
            health_worst.SetActive(true);
            health_bad.SetActive(false);
        }
    }

    // Function to handle healing the player
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    // Function to handle the player's death
    void Die()
    {
        KillPlayer.Invoke();
        // Add any additional actions you want to perform when the player dies
      //  Debug.Log("Player has died!");
        // You can add more actions like respawning, game over screen, etc.
    }
}
