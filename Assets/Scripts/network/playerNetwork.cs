using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

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

    public void gameOver(string winner)
    {
        RpcGameOver(winner);
    }

    [ClientRpc]
    public void RpcGameOver(string winner)
    {
        int win = 0; //0 for win, 1 draw 2 lost
        if (winner==gameObject.name)
        {
            win = 0;
        }
        else if (winner == "draw")
        {
            win = 1;
        }
        else
        {
            win = 2;
        }
        SilentNightMutilplayerGame.multiplayerGameController.DisplayResult(win);
    }
}
