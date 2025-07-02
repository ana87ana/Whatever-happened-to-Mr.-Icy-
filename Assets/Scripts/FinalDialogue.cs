using System.Collections;
using UnityEngine;

public class FinalSceneDialogue : MonoBehaviour
{
    public wizardText wizard;           
    public Dialog playerDialog;
    public LastScene falling;             

    [TextArea(2, 5)] public string[] wizardLines1;
    [TextArea(2, 5)] public string[] playerLines1;
    [TextArea(2, 5)] public string[] wizardLines2;
    [TextArea(2, 5)] public string[] playerLines2;
    [TextArea(2, 5)] public string[] wizardLines3;
    [TextArea(2, 5)] public string[] playerLines3;

    void Start()
    {
        StartCoroutine(RunFullDialogue());
    }

    IEnumerator RunFullDialogue()
    {
        yield return StartCoroutine(WizardTurn(wizardLines1));
        yield return StartCoroutine(PlayerTurn(playerLines1));
        yield return StartCoroutine(WizardTurn(wizardLines2));
        yield return StartCoroutine(PlayerTurn(playerLines2));
        yield return StartCoroutine(WizardTurn(wizardLines3));
        falling.StartDrop();
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(PlayerTurn(playerLines3));

        Debug.Log("Final dialogue sequence completed.");
    }

    IEnumerator WizardTurn(string[] lines)
    {
        wizard.ShowMessages(lines);

        yield return new WaitUntil(() => !wizard.messagePanel.activeSelf);
        
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator PlayerTurn(string[] lines)
{
    playerDialog.linije = lines;
    playerDialog.textComponent.text = string.Empty;

    playerDialog.gameObject.SetActive(true);
    playerDialog.StartDialogue(); 

    yield return new WaitUntil(() => !playerDialog.gameObject.activeSelf);
    yield return new WaitForSeconds(0.2f);
}
}
