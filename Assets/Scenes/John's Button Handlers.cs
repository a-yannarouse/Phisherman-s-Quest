using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ButtonHandlerJohn : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public Button ReturnButton; // Reference to the "Return to Town" button

    private Coroutine currentTextCoroutine; // To keep track of the current text coroutine

    private void Start()
    {
        // Optional: Initialize the text to be empty or a default message
        displayText.text = "";
        
        // Initially, set the button to be inactive
        ReturnButton.interactable = false;
    }

    public void OnYesButtonClicked()
    {
        StartTextAnimation("John have chosen to verify his tax information by clicking on the provided link. Unfortunately, the link led to a fake website created by cybercriminals. He unknowingly provided sensitive personal and financial information. The decision to click on the link has resulted in a security breach, and John's information is now in the hands of cybercriminals. John should immediately take steps to secure his accounts and report the incident to the authorities. In real life, it's important to be cautious when receiving unsolicited emails requesting personal or financial information. Always verify the legitimacy of such requests before taking any action.");
    }

    public void OnNoButtonClicked()
    {
        StartTextAnimation("John have chosen not to click on the link and have made the right decision. The email John received was a phishing attempt, and the link led to a fake website designed to steal personal and financial information. By not clicking on the link, John has protected his sensitive information and avoided falling victim to the scam. It's crucial to exercise caution when receiving unsolicited emails requesting personal or financial details. In real life, it is recommended to verify the legitimacy of such emails with the official tax authority or organization before taking any action. Reporting phishing attempts is also an important step in preventing cybercrime.");
    }
    private void StartTextAnimation(string message)
    {
        if (currentTextCoroutine != null)
        {
            StopCoroutine(currentTextCoroutine); // Stop the ongoing coroutine if any
        }
        currentTextCoroutine = StartCoroutine(AnimateText(message));
    }

    IEnumerator AnimateText(string message)
    {
        displayText.text = "";
        foreach (char c in message.ToCharArray())
        {
            displayText.text += c;
            yield return new WaitForSeconds(0.01f); // Adjust the speed as needed
        }
        // After the text animation finishes, activate the "Return to Town" button
        ReturnButton.interactable = true;
        currentTextCoroutine = null; // Reset the coroutine tracking
    }
}
