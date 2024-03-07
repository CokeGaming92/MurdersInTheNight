using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    // private string[] dialogLines;

    public Button[] choiceButtons;

    private string[][] dialogChoices;
    private int currentLine = 0;

    void Start()
    {
        // Initialize your dialog lines here
        dialogChoices = new string[][]
        {
            new string[] { "Welcome to our store! Can I help you find something specific?", "Just browsing, thanks." },
           
           


        };

        // Do not start the dialog here

        // Hook up button click events
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int choiceIndex = i; // Create a local variable to avoid closure-related issues
            choiceButtons[i].onClick.AddListener(() => OnButtonClick(choiceIndex));
        }
    }

    // New method to start the conversation
    public void StartConversation()
    {
        // Enable the dialog UI
        dialogText.gameObject.SetActive(true);

        // Enable choice buttons
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);
        }

        // Start the dialog
        ShowCurrentLine();
    }

    void Update()
    {
        // You can add additional input handling here if needed
    }

    void ShowCurrentLine()
    {
        dialogText.text = dialogChoices[currentLine][0];

        // Set button text based on choices
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < dialogChoices[currentLine].Length - 1)
            {
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogChoices[currentLine][i + 1];
                choiceButtons[i].gameObject.SetActive(true);
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void OnButtonClick(int choiceIndex)
    {
        // Handle button click
        currentLine = choiceIndex + 1; // Move to the next line based on the chosen option

        if (currentLine < dialogChoices.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            EndConversation();
        }
    }


    public void EndConversation()
    {
        // Disable the dialog UI
        dialogText.gameObject.SetActive(false);

        // Disable choice buttons
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }

        // Reset the dialog for potential future use
        currentLine = 0;
    }
}