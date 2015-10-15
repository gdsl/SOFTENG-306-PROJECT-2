using UnityEngine;
using System.Collections;

public class KeyScript : Items {
    public int id;
	public KeyPanelScript keyPanelScript;

    void Awake()
    {
        if(keyPanelScript == null)
        {
            keyPanelScript = GameObject.Find("KeyPanel").GetComponent<KeyPanelScript>();
        }
    }

    //when the player collider with key trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//make sure collide is with palyer
        {
            //play pick up keys audio
            AudioSource keyAudio = GameObject.FindGameObjectWithTag("KeyAudio").GetComponent<AudioSource>();
            keyAudio.Play();
            this.setPickedUp(); //set key to be picked up
            col.gameObject.GetComponent<PlayerInventory>().gotKey(id);
			keyPanelScript.updateKey(id);
        }
    }
}
