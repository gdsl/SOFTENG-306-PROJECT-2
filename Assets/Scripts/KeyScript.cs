﻿using UnityEngine;
using System.Collections;

public class KeyScript : Items {
    private int id=1;
    //when the player collider with key trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == this.getPlayer())//make sure collide is with palyer
        {
            this.setPickedUp(); //set key to be picked up
            this.getPlayerInventory().gotKey(id); //set player get this particular key
        }
    }
}