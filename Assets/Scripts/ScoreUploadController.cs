using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreUploadController : MonoBehaviour {

    private int score;

    public int level;

    public GameObject uploadScreen;
    public Text title;
    public GameObject loading;
    public GameObject nextbutton;


	// Use this for initialization
	void Start () 
    {
        uploadScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {

        loading.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
        
	}

    internal void SetScore(int finishedScore)
    {
        score = finishedScore;
    }

    public void Upload()
    {
        string url = "https://microsoft-apiapp77eee8f5a1b34710aa0e56c4970c119d.azurewebsites.net/api/Score";

        uploadScreen.SetActive(true);
        nextbutton.SetActive(false);

        WWWForm form = new WWWForm();
        form.AddField("Score", score + "");
        form.AddField("Name", PlayerPrefs.GetString("Name"));
        form.AddField("Level", level + "");

        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));

    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        loading.SetActive(false);
        nextbutton.SetActive(true);
        title.text = "Complete!";

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
