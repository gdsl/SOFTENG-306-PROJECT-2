using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuspicionController : MonoBehaviour {
	public GameObject santa;
	public Slider suspicionSlider;
	public GameObject failScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (santa.GetComponent<Rigidbody> ().position.y > 0.2) {
			IncreaseSuspicion();
		}
	}

	void IncreaseSuspicion() {
		suspicionSlider.value = suspicionSlider.value + 1;
		if (suspicionSlider.value == suspicionSlider.maxValue) {
			failScreen.SetActive(true);
		}
	}

	public void RestartLevel() {

	}

}
