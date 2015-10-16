using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

/// <summary>
/// Class to represent the player's inventory for single player
/// </summary>
public class PlayerInventorySingle : PlayerInventory
{

    public override void SetCookie()
    {
        CookieGuiUpdate();//show cookie count on gui
    }
}
