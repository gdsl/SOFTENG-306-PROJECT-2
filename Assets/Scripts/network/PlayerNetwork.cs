using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNetwork : NetworkBehaviour {
    private CameraController cc;
	// Use this for initialization
	void Start () {
	    if(isLocalPlayer){
            GameObject cam = GameObject.Find("Main Camera");
            GameObject camRef = GameObject.Find("CameraReference");
            GameObject sus = GameObject.Find("SuspicionSlider");
            cc=cam.GetComponent<CameraController>();
            camRef.transform.position = transform.position;
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
    [ClientCallback]
    [ClientRpc]
    public void RpcGameOver(string winner)
    {
        if (isLocalPlayer)
        {
            //Set screen active
            SilentNightMutilplayerGame.multiplayerGameController.resultScreen.SetActive(true);
            //resultScreen.SetActive(true);
            Text resultText = GameObject.Find("ResultText").GetComponent<Text>() ;
            if (winner == gameObject.name)
            {
                resultText.text = "You won, Query Chan !!";
                GameObject achievementController = GameObject.FindGameObjectWithTag("AchievementController");
                AchievementController controller = achievementController.GetComponent<AchievementController>();
                controller.setAchievement(AchievementController.MULTIPLAYER_WIN);
            }
            else if (winner == "draw")
            {
                resultText.text = "Query Chans got same number of cookie!!";
            }
            else
            {
                resultText.text = "You lost, Query Chan !!";
            }

            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            GameController gameControllerScript = gameController.GetComponent<GameController>();
            gameControllerScript.StopGame();
        }
    }
}
