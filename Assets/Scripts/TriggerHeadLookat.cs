
using UnityEngine;

public class TriggerHeadLookat : MonoBehaviour
{
    public GameObject headGameObject; // Reference to the head GameObject

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of your player object
        {
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}