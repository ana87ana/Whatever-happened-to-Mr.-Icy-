using UnityEngine;

public static class SaveManager
{
    private const string LastSceneKey = "LastScene";

    public static void SaveCurrentScene(string sceneName)
    {
        PlayerPrefs.SetString(LastSceneKey, sceneName);
        PlayerPrefs.Save();
    }

    public static string LoadLastScene()
    {
        return PlayerPrefs.GetString(LastSceneKey, "");
    }

    public static bool HasSave()
    {
        return PlayerPrefs.HasKey(LastSceneKey);
    }

    public static void ClearSave()
    {
        PlayerPrefs.DeleteKey(LastSceneKey);
    }
}
