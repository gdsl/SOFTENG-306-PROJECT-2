using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class LeaderboardController : MonoBehaviour {

    public GameObject leaderboard;

    private string url;

    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;
    public Text name5;

    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;

    public GameObject loading;

    // Use this for initialization
    void Start () {
        url = "https://microsoft-apiapp77eee8f5a1b34710aa0e56c4970c119d.azurewebsites.net/api/Score";
        leaderboard.SetActive(false);
        loading.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        loading.transform.FindChild("LoadingCircle").transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
	}

    public void ShowLeaderboard()
    {
        leaderboard.SetActive(true);
        loading.SetActive(true);
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

    }

    public void HideLeaderboard()
    {
        leaderboard.SetActive(false);
        loading.SetActive(false);
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        loading.SetActive(false);

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);

            SetScore(www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    
    private void SetScore(string json)
    {
        string[] tokens = json.Split(new[] { ";" }, StringSplitOptions.None);

        Debug.Log(tokens[0].Split(new[] { "," }, StringSplitOptions.None)[0]);
        Debug.Log(tokens[0].Split(new[] { "," }, StringSplitOptions.None)[1]);
        Debug.Log(tokens[1].Split(new[] { "," }, StringSplitOptions.None)[0]);
        Debug.Log(tokens[1].Split(new[] { "," }, StringSplitOptions.None)[1]);
        Debug.Log(tokens[2].Split(new[] { "," }, StringSplitOptions.None)[0]);
        Debug.Log(tokens[2].Split(new[] { "," }, StringSplitOptions.None)[1]);
        Debug.Log(tokens[3].Split(new[] { "," }, StringSplitOptions.None)[0]);
        Debug.Log(tokens[3].Split(new[] { "," }, StringSplitOptions.None)[1]);
        Debug.Log(tokens[4].Split(new[] { "," }, StringSplitOptions.None)[0]);
        Debug.Log(tokens[4].Split(new[] { "," }, StringSplitOptions.None)[1]);

        name1.text = tokens[0].Split(new[] { "," }, StringSplitOptions.None)[0].Remove(0, 1);
        score1.text = tokens[0].Split(new[] { "," }, StringSplitOptions.None)[1];

        name2.text = tokens[1].Split(new[] { "," }, StringSplitOptions.None)[0];
        score2.text = tokens[1].Split(new[] { "," }, StringSplitOptions.None)[1];

        name3.text = tokens[2].Split(new[] { "," }, StringSplitOptions.None)[0];
        score3.text = tokens[2].Split(new[] { "," }, StringSplitOptions.None)[1];

        name4.text = tokens[3].Split(new[] { "," }, StringSplitOptions.None)[0];
        score4.text = tokens[3].Split(new[] { "," }, StringSplitOptions.None)[1];

        name5.text = tokens[4].Split(new[] { "," }, StringSplitOptions.None)[0];
        score5.text = tokens[4].Split(new[] { "," }, StringSplitOptions.None)[1].TrimEnd('"');


        return;
    }
}
