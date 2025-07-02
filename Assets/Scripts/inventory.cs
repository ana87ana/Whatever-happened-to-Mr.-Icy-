using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private bool inventoryOpen = false;
    public GameObject inventoryPanel;
    public InventorySlot uiManager;
    public List<string> generalItems = new List<string>();
    public string gearSlot = "";

    void Update()
    {

        if (Input.GetKey(Keybinds.keys["Inventory"]))
        {
            inventoryOpen = !inventoryOpen;
            inventoryPanel.SetActive(inventoryOpen);
            Time.timeScale = inventoryOpen ? 0f : 1f;

            if (inventoryOpen && uiManager != null)
            {
                uiManager.RefreshUI();
            }
        }
    }
    
    public bool HasItem(string itemName)
{
    return generalItems.Contains(itemName);
}

public void RemoveItem(string itemName)
{
    generalItems.Remove(itemName);
}

public void AddGearItem(string itemName)
{
    gearSlot = itemName;
}

}
