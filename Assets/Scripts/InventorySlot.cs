using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class InventoryItem
{
    public string itemID;
    public Sprite itemIcon;
}

public class InventorySlot : MonoBehaviour
{
    public List<Image> generalSlots;
    public Image weaponSlot;
    public Image gearSlot;
    public List<InventoryItem> allItems;
    public GameObject journalUIPanel;
    public JournalUI journalUI;

    void Start()
    {
        for (int i = 0; i < generalSlots.Count; i++)
        {
            int index = i;
            generalSlots[i].GetComponent<Button>().onClick.AddListener(() => OnGeneralSlotClick(index));
        }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < generalSlots.Count; i++)
        {
            generalSlots[i].sprite = null;
            generalSlots[i].color = new Color(1, 1, 1, 0);
        }

        for (int i = 0; i < InventoryManager.Instance.generalItems.Count && i < generalSlots.Count; i++)
        {
            string id = InventoryManager.Instance.generalItems[i];
            Sprite icon = allItems.Find(x => x.itemID == id)?.itemIcon;

            if (icon != null)
            {
                generalSlots[i].sprite = icon;
                generalSlots[i].color = Color.white;
            }
        }

        if (!string.IsNullOrEmpty(InventoryManager.Instance.weaponItem))
        {
            var icon = allItems.Find(x => x.itemID == InventoryManager.Instance.weaponItem)?.itemIcon;
            if (icon != null)
            {
                weaponSlot.sprite = icon;
                weaponSlot.color = Color.white;
            }
        }

        if (!string.IsNullOrEmpty(InventoryManager.Instance.gearItem))
        {
            var icon = allItems.Find(x => x.itemID == InventoryManager.Instance.gearItem)?.itemIcon;
            if (icon != null)
            {
                gearSlot.sprite = icon;
                gearSlot.color = Color.white;
            }
        }
    }

    void OnGeneralSlotClick(int index)
    {
        if (index < InventoryManager.Instance.generalItems.Count)
        {
            string id = InventoryManager.Instance.generalItems[index];
            if (id == "journal")
            {
                journalUI.OpenJournal();
            }
        }
    }
}
