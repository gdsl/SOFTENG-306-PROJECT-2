using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CookieScript : Items {

	private Text cookieText;

	// Use this for initialization
	void Start () 
    {
		cookieText = GameObject.FindWithTag("CookieText").GetComponent<Text>() as Text;
	}

    //when the player collider with cookie trigger this event
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Player") //make sure collide is with palyer
        {
            //play eating audio 
            AudioSource eatAudio = GameObject.FindGameObjectWithTag("EatCookieAudio").GetComponent<AudioSource>();
            eatAudio.Play();
            this.setPickedUp();//set cookie to pickup
            col.gameObject.GetComponent<PlayerInventory>().IncreaseCookieCount();
        }
    }
}
