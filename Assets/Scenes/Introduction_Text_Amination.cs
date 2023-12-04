using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimator : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textComponent;
    public string fullText;
    public float typeSpeed;
    public Button nextButton; // Reference to the button

    void Start()
    {
        StartCoroutine(TypeText());
        nextButton.interactable = false; // Deactivate the button at the start
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typeSpeed);
        }
        nextButton.interactable = true; // Activate the button after text animation
    }
}


