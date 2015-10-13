using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Slider suspicionSlider;
	public GameObject failScreen;
	public GameObject successScreen;
	public Light moonlight;

	// Use this for initialization
	void Start () {
		ResumeGame ();
		failScreen.SetActive (false);
		successScreen.SetActive (false);
		Text hintText = GameObject.FindGameObjectWithTag("HintText").GetComponent<Text>();
		hintText.gameObject.SetActive(false);
		moonlight.intensity = PlayerPrefs.GetInt ("brightness");

        //stop the menu music playing
        MenuMusic menuMusic = MenuMusic.Instance;
        if(menuMusic != null)
        {
            Destroy(menuMusic.gameObject);
        }        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.LoadLevel(0); }
	}

	public void RestartLevel() {
	//	successScreen.SetActive (false);
	//	failScreen.SetActive (false);
		Application.LoadLevel(2);
	//	ResumeGame ();
	}

	public void GoToNextLevel() {
	//	successScreen.SetActive (false);
	//	failScreen.SetActive (false);
		Application.LoadLevel(1);
	//	ResumeGame ();
	}

	public void GoBackToHome() {
	//	successScreen.SetActive (false);
	//	failScreen.SetActive (false);
		Application.LoadLevel(0);
	//	ResumeGame ();
	}

	public void PauseGame() {
	//	Debug.LogError ("paused");
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void ResumeGame() {
		Time.timeScale = 1;
	}

	
	public void StopGame() {
		Time.timeScale = 0;
	}
	

}
