using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDCanvas : MonoBehaviour {

	public Text timeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = "Time: " + Time.timeSinceLevelLoad.ToString("0.00");
	}
}
