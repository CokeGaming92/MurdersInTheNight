using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillPlayer : MonoBehaviour
{
    public bool canKill;
    public PlayerHealth health;
    public float amtofDamage = 10;
    public void Update()
    {
        if (canKill)
        {
            health.TakeDamage(amtofDamage);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canKill = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canKill = false;

        }
    }
}
