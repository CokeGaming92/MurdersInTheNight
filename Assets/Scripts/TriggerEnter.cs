using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerEnter : MonoBehaviour
{
    public UnityEvent triggerEnter, triggerExit;
    public int customLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEnter.Invoke();
        }

        if(other.tag == "NPC")
        {
            triggerEnter.Invoke();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerExit.Invoke();
        }
        if (other.tag == "NPC")
        {
            triggerExit.Invoke();
        }
    }

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }

    public void LoadLevelNext()
    {
        SceneManager.LoadScene(customLevel);
    }

   
}
