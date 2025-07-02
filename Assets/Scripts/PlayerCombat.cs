using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(Keybinds.keys["Attack"]))
        {
            Attack();
        }
    }

    void Attack()
    {
        
    }
}
