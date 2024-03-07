using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EscapeToMainMenu : MonoBehaviour
{
    public GameObject uiCanvas;
   

    private void Start()
    {
        // Ensure the UI Canvas is not active at the beginning
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor at the start
        Cursor.visible = false;
    }

    private void Update()
    {
        // Check for the E key press to trigger the escape to the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the UI Canvas
            if (uiCanvas != null)
            {
                Cursor.lockState = CursorLockMode.None;
                // Toggle cursor visibility based on UI Canvas activation
                Cursor.visible = !uiCanvas.activeSelf;
                uiCanvas.SetActive(!uiCanvas.activeSelf);
            }
     

        

        }
    }


    public void OnYesButtonClick()
    {
       
            SceneManager.LoadScene(0);
           
        
    }
    public void OnNoButtonClick()
    {
        // Implement the action for canceling (staying in the current scene)
        // For example, hide the UI Canvas
        if (uiCanvas != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            uiCanvas.SetActive(false);
        }
    }
}