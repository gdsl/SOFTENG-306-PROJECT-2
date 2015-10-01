using UnityEngine;
using System.Collections;

public class CookieScript : Items {
    //when the player collider with cookie trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == this.getPlayer()) //make sure collide is with palyer
        {
            this.setPickedUp();//set cookie to pickup
            this.getPlayerInventory().IncreaseCookieCount();//increase cookie count
        }
    }
}
