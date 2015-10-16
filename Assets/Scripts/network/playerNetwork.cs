﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNetwork : NetworkBehaviour {
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
        }
	}

    //when game is over display results
    public void gameOver(string winner)
    {
        if (isLocalPlayer)
        {
            Text resultText = GameObject.Find("ResultText").GetComponent<Text>();
            if (winner == gameObject.name)
            {
                resultText.text = "You won, Query Chan !!";
            }
            else if (winner == "draw")
            {
                resultText.text = "Query Chans got same number of cookie!!";
            }
            else
            {
                resultText.text = "You lost, Query Chan !!";
            }
        }
    }
}
