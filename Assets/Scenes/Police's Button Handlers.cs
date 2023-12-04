using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ButtonHandlerPolice : MonoBehaviour
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
        StartTextAnimation("The Chief has chosen to pay the ransom. The Chief sent 1 Bitcoin (BTC) to the provided address as instructed in the email. Unfortunately, despite their compliance, the cybercriminals do not uphold their end of the deal. The funds are gone, and the police data is still at risk. The criminals have not released the data, and the chief are left with a financial loss. Remember, paying ransoms to cybercriminals is never a guarantee that they will honor their promises. In real life, it is strongly discouraged, as it only encourages criminal activity and may not result in data recovery.");
    }

    public void OnNoButtonClicked()
    {
        StartTextAnimation("The Chief have chosen not to pay the ransom. Instead, they take the wise step of reporting the incident to the appropriate authorities, such as the rest of the police and cybersecurity experts. They work together to investigate and mitigate the threat. The authorities are successful in tracing the cybercriminals and stopping further threats. The data remains secure, and you've contributed to the fight against cybercrime. Remember, in real life, it is strongly recommended to never pay ransoms to cybercriminals, as there is no guarantee that they will uphold their end of the bargain. Reporting such incidents is the safest course of action.");
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
