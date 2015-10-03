using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiUpdate : MonoBehaviour {
    public Text cookieText;
    public Text keyText;

	// Update is called once per frame
	void Update () {
        //show cookie count
        PlayerInventory playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        cookieText.text = "Cookies: " + playerInventory.getCookieCount();
        if (playerInventory.hasKey(1))
        {
            keyText.text = "Key: Have Key";
        }
        else
        {
            keyText.text = "Key: Need Key";
        }

	}
}
