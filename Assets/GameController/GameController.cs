using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject failScreen;

	// Use this for initialization
	void Start () {
		failScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RestartLevel() {
		failScreen.SetActive (false);
		Application.LoadLevel(2);
	}
}
