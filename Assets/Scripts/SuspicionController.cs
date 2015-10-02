using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuspicionController : MonoBehaviour {
	public GameObject santa;
	public Slider suspicionSlider;

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
	}

	public void IncreaseSuspicionByAmount(int amount) {
		suspicionSlider.value = suspicionSlider.value + amount;
	}

}
