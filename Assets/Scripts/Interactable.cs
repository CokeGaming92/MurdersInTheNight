using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public KeyCode interactKeyCode;
    public bool isInteracted;
    public UnityEvent interactEvent, interactEvent2;
   
    public UnityEvent unityEvent;
    void Update()
    {
        if (Input.GetKeyDown(interactKeyCode))
        {
            isInteracted = !isInteracted;
            if (isInteracted)
            {
                interactEvent.Invoke();
            }
            if (!isInteracted)
            {
                interactEvent2.Invoke();
            }
        }

       
    }

    public void LoadEnemy()
    {
        unityEvent.Invoke();
    }
}
