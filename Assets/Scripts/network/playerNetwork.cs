using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerNetwork : NetworkBehaviour {
    private CameraController cc;
	// Use this for initialization
	void Start () {
	    if(isLocalPlayer){
            GameObject cam = GameObject.Find("Main Camera");
            cc=cam.GetComponent<CameraController>();
            cc.santa = gameObject;
            //isoCamera.enabled = true;
            //isoCamera.cameraComponent
            //GetComponent<CharacterController>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled=true;
        }
	}
}
