using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerNetwork : NetworkBehaviour {
    private CameraController cc;
	// Use this for initialization
	void Start () {
	    if(isLocalPlayer){
            GameObject cam = GameObject.Find("Main Camera");
            GameObject sus = GameObject.Find("SuspicionSlider");
            cc=cam.GetComponent<CameraController>();
            cc.transform.position = transform.position;
            sus.GetComponent<SuspicionController>().santa=gameObject;
            cc.santa = gameObject;
            cc.InitialiseCamera();
            cc.enabled = true;
            //isoCamera.enabled = true;
            //isoCamera.cameraComponent
            //GetComponent<CharacterController>().enabled = true;
            Debug.Log(Network.player.ToString());
        }
	}
}
