using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class SilentNightMutilplayerGame : NetworkBehaviour
{
    [SyncVar]
    bool isGameOver = false; //variable to flag if the game is over or not
    static public SilentNightMutilplayerGame multiplayerGameController;
    public GameObject cookieGenerator;
    private GameObject cookie = null;


    [SyncVar]
    private float gameDuration = 60; //in seconds
                                     // Initialise when first created
    void Awake()
    {
        multiplayerGameController = this;
    }

    //when server start up
    public override void OnStartServer()
    {
        //initialise count down timer
        gameDuration = 60;
        //generate cookie when first start up
        generateCookie();
    }

    // Update is called once per frame
    [ServerCallback]
    void Update()
    {
        if (isGameOver)
        {
            return;
            //do logic then shut down
        }

        gameDuration -= Time.deltaTime;
        if (gameDuration <= 0)
        {
            ExitGame();//exit game
        }

        if (cookie == null)//if cookie collected regenerate
        {
            generateCookie();
        }

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
        cookie = cookieGenerator.GetComponent<CookieGenerator>().generateCookie();
        NetworkServer.Spawn(cookie);
    }

    public float GetTimeLeft()
    {
        return gameDuration;
    }
}
