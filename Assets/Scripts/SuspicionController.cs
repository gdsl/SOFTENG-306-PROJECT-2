using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuspicionController : MonoBehaviour {
	public GameObject santa;
	public Slider suspicionSlider;
	public GameObject failScreen;
	public Text failText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (santa.GetComponent<Rigidbody> ().velocity.magnitude > 0.2) {
			//Debug.Log(santa.GetComponent<Rigidbody>().velocity.magnitude);
			IncreaseSuspicionByAmount(santa.GetComponent<Rigidbody> ().velocity.magnitude/2);
		} 
	}

	void IncreaseSuspicion() {
		IncreaseSuspicionByAmount (1);
	}

	public void IncreaseSuspicionByAmount(float amount) {
		suspicionSlider.value = suspicionSlider.value + amount;
		if (suspicionSlider.value == suspicionSlider.maxValue) {
			failText.text = "You have woken up everybody! \nCops are on their way";
			failScreen.SetActive(true);
		}
	}

}
