using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> generalItems = new List<string>();
    public List<string> journalPages = new List<string>();
    public string weaponItem = "";
    public string gearItem = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemID, string tag)
    {
        if (tag == "weapon")
        {
            weaponItem = itemID;
            Debug.Log("Picked up weapon: " + itemID);
        }
        else if (tag == "gear")
        {
            gearItem = itemID;
            Debug.Log("Picked up gear: " + itemID);
        }
        else if (tag == "journalpage")
        {
            if (!journalPages.Contains(itemID))
            {
                journalPages.Add(itemID);
                journalPages.Sort();
                Debug.Log("Picked up journal page: " + itemID);
            }
        }
        else 
        {
            if (!generalItems.Contains(itemID))
            {
                generalItems.Add(itemID);
                Debug.Log("Picked up item: " + itemID);
            }
        }
    }

    public bool HasJournalPage(string id)
    {
        return journalPages.Contains(id);
    }
}
