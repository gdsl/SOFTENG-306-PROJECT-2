﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

/// <summary>
/// Class to represent the player's inventory
/// </summary>
public abstract class PlayerInventory : NetworkBehaviour
{
    private Dictionary<int, bool> keyInventory = new Dictionary<int, bool>();
    private long cookieCount;
    private Text cookieText;

    // initialise the player inventory
    void Start()
    {
        cookieCount = 0;
        cookieText = GameObject.Find("CookieText").GetComponent<Text>();
    }

    //method to setCookieCount
    public void SetCookieCount(long count)
    {
        cookieCount = count;
        SetCookie();
    }

    //method to increase the players cookie count by 1
    public void IncreaseCookieCount()
    {
        cookieCount = cookieCount + 1;
        SetCookie();
    }

    //method to get number of cookie collected
    public long GetCookieCount()
    {
        return cookieCount;
    }

    //method to add a key into player inventory
    public void GotKey(int id)
    {
        keyInventory.Add(id, true);
    }

    //method to check if a player have a particular key using the key's id
    public bool HasKey(int id)
    {
        bool haskey = false;
        if (keyInventory.ContainsKey(id) && keyInventory[id] == true)
        {
            haskey = true;
        }
        return haskey;
    }

    //method to reset the players inventory
    public void ResetCookie()
    {
        cookieCount = 0;
        cookieText = GameObject.Find("CookieText").GetComponent<Text>();
    }

    //Method to update the number of cookie collected at the gui HUD
    protected void CookieGuiUpdate()
    {
        cookieText.text = "Cookies: " + cookieCount;
    }

    //abstract method to be implemented by inherited class
    abstract public void SetCookie();
}
