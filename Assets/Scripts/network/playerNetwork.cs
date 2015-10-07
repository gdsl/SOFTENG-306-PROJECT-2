using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerNetwork : NetworkBehaviour {

    [SerializeField]Camera isoCamera;
	// Use this for initialization
	void Start () {
	    if(isLocalPlayer){
            GameObject.Find("Main Camera").SetActive(false);
            GetComponent<CharacterController>().enabled = true;
            
        }
	}
}
