using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionsMet : MonoBehaviour
{
    public int customNumber;
    public UnityEvent InteractionMet;

    void Start()
    {
        
    }

 

    public void InteractionCountdown()
    {
        customNumber = customNumber - 1;

        if (customNumber <= 0)
        {
            InteractionMet.Invoke();
        }
    }
}
