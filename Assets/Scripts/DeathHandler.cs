using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimator()
    {
        animator.Play("Death");
    }
    // Method to be called from animation event
    public void OnDeathAnimationEndEvent()
    {
        // Perform actions when the death animation ends
        Destroy(transform.parent.gameObject); // Destroy the parent GameObject after the death animation
    }
}
