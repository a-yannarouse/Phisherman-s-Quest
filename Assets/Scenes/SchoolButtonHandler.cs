using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class SchoolButtonHandler : MonoBehaviour
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
        StartTextAnimation("The student has chosen to connect to the Wi-Fi network without verifying its authenticity. Unfortunately, the network you connected to was a rogue evil twin network set up by cybercriminals. By connecting to this network, the student unknowingly exposed your device to potential security risks. Cybercriminals may have gained access to the student personal information. In real life, it's important to verify the authenticity of Wi-Fi networks, especially in public places like schools. Always ensure you connect to the official network and report any suspicious activity to IT or network administrators to prevent security breaches.");
    }

    public void OnNoButtonClicked()
    {
        StartTextAnimation("The student has chosen not to connect to the Wi-Fi network and have made the right decision. You made the right choice. The network the student detected was a rogue evil twin network, a common tactic used by cybercriminals to steal information. By avoiding the connection and reporting the suspicious network to IT, the student has protected their device and personal information from potential threats. It's essential to exercise caution and report any suspicious Wi-Fi networks to the authorities or IT experts. In real life, always verify the authenticity of Wi-Fi networks in public places to ensure your online security and privacy.");
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