using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemID;

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (itemID == "page")
        {
            if (JournalProgress.Instance != null)
            {
                JournalProgress.Instance.UnlockNextPage();
            }

            Destroy(gameObject); 
        }
        else
        {
            string tag = gameObject.tag.ToLower();
            InventoryManager.Instance.AddItem(itemID, tag);
            Destroy(gameObject);
        }
    }
}

}
