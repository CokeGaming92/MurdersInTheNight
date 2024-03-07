using UnityEngine;

public class Trigger_Dialog : MonoBehaviour
{
    public DialogManager dialogManager;
    bool dialogStart;
    bool isCursorLocked;


     void Start()
    {
        

    }
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
       
        
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        
        if (other.CompareTag("Player"))
        {
            dialogStart = true;
            isCursorLocked = false;
            OnConversationStart();

        }


    }

    void OnConversationStart()
    {
        
            // Trigger the conversation when the player enters the trigger zone
            dialogManager.StartConversation();
            // Disable the collider to prevent continuous triggering
            //  GetComponent<Collider>().enabled = false;
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogStart = false;
            isCursorLocked = true;
        }
        
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
    }
}