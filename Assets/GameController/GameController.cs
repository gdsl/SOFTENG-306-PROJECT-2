using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject santa;
	public GameObject cameraController;
//	public GameObject animal; //could change to a list? not sure if it works with Unity associations
//	public GameObject human; //could change to a list? not sure if it works with Unity associations
//	public GameObject room;

	public Slider suspicionSlider;

	// Use this for initialization
	void Start () {
		//santa = GameObject.FindGameObjectWithTag ("Santa");
	}
	
	// Update is called once per frame
	void Update () {
		if (santa.GetComponent<Rigidbody> ().position.y > 0) {
			IncreaseSuspicion();
		}
	}

	void IncreaseSuspicion() {
		suspicionSlider.value = suspicionSlider.value + 1;
	}

}
