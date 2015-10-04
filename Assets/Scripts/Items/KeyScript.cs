using UnityEngine;
using System.Collections;

public class KeyScript : Items {
    public int id;

    //when the player collider with key trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == this.getPlayer())//make sure collide is with palyer
        {
            //play pick up keys audio
            AudioSource keyAudio = GameObject.FindGameObjectWithTag("KeyAudio").GetComponent<AudioSource>();
            keyAudio.Play();
            this.setPickedUp(); //set key to be picked up
            this.getPlayerInventory().gotKey(id); //set player get this particular key
        }
    }
}
