using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class wizardText : MonoBehaviour
{
    public GameObject messagePanel;
    public Text messageText;
    public GameObject shopPanel;

    public float typeSpeed = 0.05f;
    public AudioClip typeSound;
    public AudioSource audioSource;

    private string[] currentMessages;
    private int messageIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Update()
    {
        if (messagePanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                messageText.text = currentMessages[messageIndex];
                isTyping = false;
            }
            else
            {
                messageIndex++;
                if (messageIndex < currentMessages.Length)
                {
                    typingCoroutine = StartCoroutine(TypeLine(currentMessages[messageIndex]));
                }
                else
                {
                    HideMessage();
                }
            }
        }
    }

    public void ShowMessages(string[] messages)
    {
        currentMessages = messages;
        messageIndex = 0;
        messagePanel.SetActive(true);
        StopAllCoroutines();
        typingCoroutine = StartCoroutine(TypeLine(currentMessages[messageIndex]));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        messageText.text = "";

        foreach (char c in line)
        {
            messageText.text += c;

            if (typeSound != null && audioSource != null && !char.IsWhiteSpace(c))
            {
                audioSource.PlayOneShot(typeSound);
            }

            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }

    public void HideMessage()
    {
        messagePanel.SetActive(false);
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }
}
