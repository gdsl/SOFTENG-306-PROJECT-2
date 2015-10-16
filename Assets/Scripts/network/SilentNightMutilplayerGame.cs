﻿using UnityEngine;
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
    public Text resultText;

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
        //generate cookie when first start up
        generateCookie();

        //initialise dynamic obstalce (people)
        /*GameObject carl = GameObject.Find("Carl");
        carl.GetComponent<PersonAnimation>().InitialiseSantaTransform();
        carl.GetComponent<SleepingPersonAI>().InitialiseSantaTransform();
         */
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

        //check if timer pass zero if it does it stop at 0
        if (gameDuration - Time.deltaTime<0)
        {
            gameDuration = 0;
        }else{
            gameDuration -= Time.deltaTime;
        }
        
        if (gameDuration <= 0)
        {
            //ExitGame();//exit game
            //NetworkServer.
            GameObject[] query = GameObject.FindGameObjectsWithTag("Player");
            long countPlayer1 =query[0].GetComponent<PlayerInventory>().getCookieCount();
            long countPlayer2 = query[1].GetComponent<PlayerInventory>().getCookieCount();
            if(countPlayer1>countPlayer2){
                resultText.text = query[0].name+ " Won";
            }else if(countPlayer1==countPlayer2){
                resultText.text = "Query Chans got same number of cookie!!";
            }else{
                resultText.text = query[1].name + " Won";
            }
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
