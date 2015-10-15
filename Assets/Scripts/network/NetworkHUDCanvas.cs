using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class NetworkHUDCanvas : NetworkBehaviour {

    public Text timeText;
    public SilentNightMutilplayerGame multiplayerGame;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int rtt = 0;
        if (NetworkClient.allClients.Count > 0)
        {
            for (int i = 0; i < NetworkClient.allClients.Count; i++) {
                NetworkConnection c = NetworkClient.allClients[i].connection;

                if (c == null)
                {
                    continue;
                }
                byte error;
                rtt = NetworkTransport.GetCurrentRtt(c.hostId, c.connectionId, out error) / 2;
            }
        }


        TimeSpan t = TimeSpan.FromSeconds((multiplayerGame.GetTimeLeft()- (rtt/1000)));
        string result = string.Format("{0:00}:{1:00}:{2:00}", Math.Floor(t.TotalMinutes), t.Seconds, t.Milliseconds);
        timeText.text = "Time: " + result;
        
        
    }
}
