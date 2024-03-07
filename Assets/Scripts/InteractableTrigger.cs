using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableTrigger : MonoBehaviour
{
    public string stringText;

    public UnityEvent interactEvent, interactEvent2;
    [SerializeField] private bool hasInteracted = false;
    public TextMeshProUGUI textInteract;

    private void Update()
    {
        if (hasInteracted)
        {
            textInteract.enabled = true;

            textInteract.text = stringText;
            interactEvent.Invoke();
        }
        if(!hasInteracted)
        {
            interactEvent2.Invoke();
            textInteract.enabled = false;
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasInteracted && other.CompareTag("Player"))
        {
         
            hasInteracted = true; // Mark interaction as done
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // You may not need to handle anything on exit, but you can add logic if needed
        hasInteracted = false; // Mark interaction as done
       
    }
}
