using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] tutorialMessages;
    public bool isShopTrigger = false;
    private bool triggered = false;

    private wizardText npcUI;

    void Start()
    {
        npcUI = FindFirstObjectByType<wizardText>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            if (isShopTrigger)
            {
                npcUI.OpenShop();
            }
            else
            {
                npcUI.ShowMessages(tutorialMessages);
            }

            triggered = true;
        }
    }
}
