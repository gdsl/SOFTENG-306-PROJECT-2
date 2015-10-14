using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SilentNightMutilplayerGame : NetworkBehaviour
{
    [SyncVar] 
	bool isGameOver = false; //variable to flag if the game is over or not
    private int counter = 1000;//temporary variable to emulate timer
    static public SilentNightMutilplayerGame multiplayerGameController;
    public GameObject cookieGenerator;
    public GameObject cookie=null;
	// Initialise when first created
    void Awake()
    {
        multiplayerGameController = this;
    }

    //when server start up
    public override void OnStartServer()
    {
        //initialise count down timer
        counter = 1000;
        //generate cookie when first start up
        generateCookie();
    }

	// Update is called once per frame
    [ServerCallback]
	void Update () {
        if (isGameOver)
        {
            return;
            //do logic then shut down
        }

        if (counter <= 0)
        {
            ExitGame();//exit game
        }

        if(cookie==null)//if cookie collected regenerate
        {
            generateCookie();
        }
        
        counter--;
        Debug.Log("Counter: "+counter);
	}

    //method to shut down the server and client when game is done
    public void ExitGame()
    {
        if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
        if (NetworkClient.active)
        {
            NetworkManager.singleton.StopClient();
        }
    }

    private void generateCookie()
    {
        cookie=cookieGenerator.GetComponent<CookieGenerator>().generateCookie();
        NetworkServer.Spawn(cookie);
    }
}
