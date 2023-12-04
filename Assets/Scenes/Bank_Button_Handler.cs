using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; 
public class ButtonHandlerBank : MonoBehaviour
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
        StartTextAnimation("The message you received was indeed a phishing attempt. Here is why: The email uses a generic greeting, addressing the recipient as Dear Valued Customer instead of their name. It creates a sense of urgency by claiming that failure to act within 24 hours will result in an account suspension. The email contains a suspicious link (www.bankguardsecureverify.com) that doesn't lead to the official bank website.");
    }

    public void OnNoButtonClicked()
    {
        StartTextAnimation("You made the right decision by not clicking on the link. The message you received was indeed a phishing attempt, and here is why: The email uses a generic greeting, addressing the recipient as Dear Valued Customer instead of their name. It creates a sense of urgency by claiming that failure to act within 24 hours will result in an account suspension. The email contains a suspicious link (www.bankguardsecureverify.com) that doesn't lead to the official bank website.");
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



