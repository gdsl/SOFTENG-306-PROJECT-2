using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

/// <summary>
/// Class to represent the player's inventory for network
/// </summary>
public class PlayerInventoryNetwork : PlayerInventory{

    public override void setCookie()
    {
		if (isLocalPlayer)//only update at player who got cookies
	    {
            cookieGuiUpdate();//show cookie count on gui
	    }
    }
}
