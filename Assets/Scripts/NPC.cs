
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{

  
    
   
    public GameObject npcDialogue;



    private void Update()
    {
        InteractWithNPC();
    }


     void InteractWithNPC()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            npcDialogue.SetActive(true);
        }

        // Add your other interaction logic here
    }
}