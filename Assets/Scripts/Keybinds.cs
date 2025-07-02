using UnityEngine;
using System.Collections.Generic;

public static class Keybinds
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>()
    {
        { "Left", KeyCode.LeftArrow },
        { "Right", KeyCode.RightArrow },
        { "Jump", KeyCode.UpArrow },
        { "Inventory", KeyCode.Tab },
        { "Interact", KeyCode.E },
        { "Journal", KeyCode.F },
        { "Pause", KeyCode.Escape },
        { "Attack", KeyCode.LeftShift }
    };

    public static void SaveKeybinds()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString("keybind_" + key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }

    // Load bindings
    public static void LoadKeybinds()
    {
        var keysToLoad = new List<string>(keys.Keys);

        foreach (var key in keysToLoad)
        {
            string savedKey = PlayerPrefs.GetString("keybind_" + key, keys[key].ToString());

            if (System.Enum.TryParse(savedKey, out KeyCode loadedKey))
            {
                keys[key] = loadedKey;
            }
        }
    }
}
