using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class to represent the player's inventory
/// </summary>
public class PlayerInventory : MonoBehaviour {
    private Dictionary<int, bool> keyInventory = new Dictionary<int, bool>();
    private long cookieCount;

	// Use this for initialization
	void Start () {
        cookieCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Cookie count: " + cookieCount);//log count for cookie
        foreach(KeyValuePair<int,bool> key in keyInventory){
            Debug.Log("Key id : " + key.Key+"; Key got : "+key.Value);//log key id and has
        }
        
	}
    
    //method to increase the players cookie count by 1
    public void IncreaseCookieCount()
    {
        cookieCount = cookieCount + 1;
    }

	public long getCookieCount() {
		return cookieCount;
	}

    public void gotKey(int id)
    {
        keyInventory.Add(id, true);
    }

    public bool hasKey(int id)
    {
        bool haskey=false;
        if (keyInventory.ContainsKey(id)&&keyInventory[id]==true)
        {
            haskey = true;
        }
        return haskey;
    }
}
