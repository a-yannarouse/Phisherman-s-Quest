using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class ButtonHandlerFactory : MonoBehaviour
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
        StartTextAnimation("The message you received was indeed a phishing attempt. Here is why: The message used vague language and a generic greeting. It asked you to click on a link without verifying your identity. Always be cautious when receiving unsolicited messages with promises of rewards. To stay safe, never click on suspicious links or provide personal information unless you're certain of the sender's legitimacy.");
    }

    public void OnNoButtonClicked()
    {
        StartTextAnimation("You made the right decision by not clicking on the link. The message you received was indeed a phishing attempt, and here is why: The message used vague language and a generic greeting. It asked you to click on a link without verifying your identity. Always be cautious when receiving unsolicited messages with promises of rewards. To stay safe, never click on suspicious links or provide personal information unless you're certain of the sender's legitimacy.");
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

