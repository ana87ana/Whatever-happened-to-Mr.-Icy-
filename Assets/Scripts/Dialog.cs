using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textComponent;              
    public string[] linije;               
    public float textSpeed = 0.05f;        

    public AudioSource audioSource;         
    public AudioClip typeSound;            

    private int index = 0;
    private bool isTyping = false;

    void Start()
    {
        textComponent.text = string.Empty;

        if (linije != null && linije.Length > 0)
        {
            StartDialogue();
        }
        else
        {
            Debug.LogWarning("No lines assigned to 'linije' array!");
        }
    }

    void Update()
    {
        if (linije == null || index >= linije.Length)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                textComponent.text = linije[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char c in linije[index])
        {
            textComponent.text += c;

            
            if (typeSound != null && audioSource != null && !char.IsWhiteSpace(c))
            {
                audioSource.PlayOneShot(typeSound);
            }

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void NextLine()
    {
        if (index < linije.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);  
        }
    }
}
