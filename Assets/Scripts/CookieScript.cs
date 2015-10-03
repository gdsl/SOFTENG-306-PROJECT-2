using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CookieScript : Items {

	public Text cookieText;

	// Use this for initialization
	void Start () {
		cookieText = GameObject.FindWithTag("CookieText").GetComponent<Text>() as Text;
	}

    //when the player collider with cookie trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == this.getPlayer()) //make sure collide is with palyer
        {
            this.setPickedUp();//set cookie to pickup
            this.getPlayerInventory().IncreaseCookieCount();//increase cookie count
			cookieText.text = "Cookies: " + this.getPlayerInventory().getCookieCount();
        }
    }
}
