using UnityEngine;

public class GearNPC : MonoBehaviour
{
    public string[] requiredItems = { };
    
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (HasAllRequiredItems())
            {
                RemoveRequiredItems();
                GiveScubaGear();
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    private bool HasAllRequiredItems()
    {
        foreach (string item in requiredItems)
        {
            if (!InventoryManager.Instance.generalItems.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

    private void RemoveRequiredItems()
    {
        foreach (string item in requiredItems)
        {
            InventoryManager.Instance.generalItems.Remove(item);
        }

        RefreshInventoryUI(); 
    }

    private void GiveScubaGear()
    {
        InventoryManager.Instance.gearItem = "Gear";
        RefreshInventoryUI(); 
    }

    private void RefreshInventoryUI()
    {
        var uiManager = FindAnyObjectByType<InventorySlot>(); 
        if (uiManager != null)
        {
            uiManager.RefreshUI();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
