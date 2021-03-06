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
    public GameObject resultScreen;

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
        //stop the menu music playing
        MenuMusic menuMusic = MenuMusic.Instance;
        if (menuMusic != null)
        {
            Destroy(menuMusic.gameObject);
        }

        //initialise count down timer  
        gameDuration = 90;  

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
        if ((gameDuration - Time.deltaTime)<0)
        {
            gameDuration = 0;
        }else{
            gameDuration -= Time.deltaTime;
        }
        
        if (gameDuration <= 0)
        {
            //ExitGame();//exit game
            //NetworkServer.
            isGameOver = true;
            NotifyResult();
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

    //Method to notify client which player won
    public void NotifyResult()
    {
        GameObject[] querys = GameObject.FindGameObjectsWithTag("Player");

        if (querys.Length > 0)
        {
            //sort query base on cookiecount
            Array.Sort(querys, delegate(GameObject query1, GameObject query2)
            {
                return query1.GetComponent<PlayerInventory>().GetCookieCount().CompareTo(query2.GetComponent<PlayerInventory>().GetCookieCount());
            });
            Array.Reverse(querys);
            //check if its there is draw
            int drawpos = 0;
            for (int i = 0; i < querys.Length; i++)
            {
                if (querys[0].GetComponent<PlayerInventory>().GetCookieCount() == querys[i].GetComponent<PlayerInventory>().GetCookieCount())
                {
                    drawpos = i;
                }
            }

            //publish result to clients for winners
            if (drawpos == 0)
            {
                querys[0].GetComponent<PlayerNetwork>().RpcGameOver(querys[0].name);
            }
            else
            {
                //publish result to clients for draws
                for (int j = 0; j < drawpos + 1; j++)
                {
                    querys[j].GetComponent<PlayerNetwork>().RpcGameOver("draw");
                }
            }

            //publish result to clients for losers
            for (int k = drawpos + 1; k < querys.Length; k++)
            {
                querys[k].GetComponent<PlayerNetwork>().RpcGameOver(querys[0].name);
            }
        }
    }
}
