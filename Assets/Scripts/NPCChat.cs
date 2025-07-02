using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCChat : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text nameText;
    public Text dialogueText;
    public float textSpeed = 0.05f;

    private string[] lines;
    private int index;
    private bool isTyping;
    private bool isDialogueActive;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialogueActive) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                isTyping = false;
            }
            else
            {
                index++;
                if (index < lines.Length)
                {
                    StartCoroutine(TypeLine());
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    public void StartDialogue(string npcName, string[] npcLines)
    {
        nameText.text = npcName;
        lines = npcLines;
        index = 0;
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }
}