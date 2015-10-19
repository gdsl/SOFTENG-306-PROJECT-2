using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
    {
        float f = Random.value + 0.5f;
        this.gameObject.GetComponent<Light>().intensity = f;
	}
}
