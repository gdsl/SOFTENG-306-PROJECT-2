using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Slider suspicionSlider;
	public GameObject failScreen;
	public GameObject successScreen;


	// Use this for initialization
	void Start () {
		failScreen.SetActive (false);
		successScreen.SetActive (false);
        //stop the menu music playing
        MenuMusic menuMusic = MenuMusic.Instance;
        Destroy(menuMusic.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RestartLevel() {
		successScreen.SetActive (false);
		failScreen.SetActive (false);
		Application.LoadLevel(2);
	}

	public void GoToNextLevel() {
		successScreen.SetActive (false);
		failScreen.SetActive (false);
		Application.LoadLevel(1);
	}

	public void GoBackToHome() {
		successScreen.SetActive (false);
		failScreen.SetActive (false);
		Application.LoadLevel(0);
	}

}
