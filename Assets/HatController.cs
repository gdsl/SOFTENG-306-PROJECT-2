using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

    GameObject glasses;

	// Use this for initialization
	void Start () {
        glasses = GameObject.FindGameObjectWithTag("Sunglasses");
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = glasses.gameObject.transform.position + new Vector3(-0.005f, 1.45f, 0.044f);
    }
}
