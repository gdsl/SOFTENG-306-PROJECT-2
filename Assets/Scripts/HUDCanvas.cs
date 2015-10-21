using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDCanvas : MonoBehaviour {

	public Text timeText;
	public GameObject successScreen;
	public GameObject failScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!failScreen.activeInHierarchy && !successScreen.activeInHierarchy) {
			timeText.text = "Time: " + Time.timeSinceLevelLoad.ToString ("0.00");
		}
	}
}
