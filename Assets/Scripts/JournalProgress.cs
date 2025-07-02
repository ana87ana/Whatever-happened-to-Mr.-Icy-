using UnityEngine;

public class JournalProgress : MonoBehaviour
{
    public static JournalProgress Instance;
    
    public int unlockedPageCount = 0; 
    public int maxPageCount = 22; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public int GetTotalReadablePages()
    {
        return 2 + unlockedPageCount; 
    }

    public void UnlockNextPage()
    {
        if (unlockedPageCount + 2 < maxPageCount)
            unlockedPageCount++;
    }
}
