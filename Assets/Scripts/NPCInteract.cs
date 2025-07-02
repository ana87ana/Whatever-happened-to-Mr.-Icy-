using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public string npcName;
    [TextArea(2, 5)]
    public string[] dialogueLines;

    private bool playerInRange = false;

    public void Start()
    {
        Keybinds.LoadKeybinds();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(Keybinds.keys["Interact"]))
        {
            NPCChat dm = FindFirstObjectByType<NPCChat>();
            dm.StartDialogue(npcName, dialogueLines);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
} 