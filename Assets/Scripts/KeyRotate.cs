using UnityEngine;
using System.Collections;

public class KeyRotate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    //make key rotate to make attract player's attention
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
