using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class KeyDropdown : MonoBehaviour
{
    public string actionName; 
    public Dropdown dropdown; 

    void Start()
    {
        if (dropdown == null)
            dropdown = GetComponent<Dropdown>();

        dropdown.ClearOptions();

        var keyNames = Enum.GetNames(typeof(KeyCode));
        List<string> keyList = new List<string>(keyNames);
        dropdown.AddOptions(keyList);

        KeyCode currentKey = Keybinds.keys.ContainsKey(actionName) ? Keybinds.keys[actionName] : KeyCode.None;
        int index = keyList.IndexOf(currentKey.ToString());
        dropdown.value = index >= 0 ? index : 0;
        dropdown.RefreshShownValue();

        dropdown.onValueChanged.AddListener(OnKeyChanged);
    }

    void OnKeyChanged(int index)
    {
        string selectedKeyName = dropdown.options[index].text;

        if (Enum.TryParse(selectedKeyName, out KeyCode newKey))
        {
            Keybinds.keys[actionName] = newKey;
            Keybinds.SaveKeybinds();
        }
    }
}
