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
        //initialise count down timer  
        gameDuration = 10;  

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
            resultScreen.SetActive(true);
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
        GameObject[] query = GameObject.FindGameObjectsWithTag("Player");
        long countPlayer1 = query[0].GetComponent<PlayerInventory>().getCookieCount();
        long countPlayer2=-1;//initialse as negative so will be lower

        if (query.Length > 1)
        {
            countPlayer2 = query[1].GetComponent<PlayerInventory>().getCookieCount();
            if (countPlayer1 > countPlayer2)
            {
                query[0].GetComponent<PlayerNetwork>().RpcGameOver(query[0].name);
                query[1].GetComponent<PlayerNetwork>().RpcGameOver(query[0].name);

            }
            else if (countPlayer1 == countPlayer2)
            {
                query[0].GetComponent<PlayerNetwork>().RpcGameOver("draw");
                query[1].GetComponent<PlayerNetwork>().RpcGameOver("draw");
            }
            else
            {
                query[0].GetComponent<PlayerNetwork>().RpcGameOver(query[1].name);
                query[1].GetComponent<PlayerNetwork>().RpcGameOver(query[1].name);
            }
        }
        else
        {
            query[0].GetComponent<PlayerNetwork>().RpcGameOver(query[0].name);
        }
    }
}
