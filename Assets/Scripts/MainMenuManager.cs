using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public int customLevel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }





    public void StartGame()
    {
  

        // Load the game scene
        SceneManager.LoadScene(customLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene(customLevel);
    }

    public void ContinueGame()
    {
        // Continue game logic here
    }


}