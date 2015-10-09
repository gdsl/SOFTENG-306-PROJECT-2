using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
    public GameObject santa;
    public bool on;
    private Light lights;
    private int count = 0;
	// Use this for initialization
    void Awake() {
        lights = this.gameObject.GetComponent<Light>();
        lights.intensity = 0.1f;
    }

	void OnTriggerEnter (Collider col) {
        if (col.gameObject == santa) {
            count++;
        }


	}

    void OnTriggerExit(Collider col) {
        if (col.gameObject == santa)
        {
            count--;
        }
            
    }

	
	// Update is called once per frame
	void Update () {
        if (count > 0)
        {
            if (lights.intensity < 0.3f) {
                lights.intensity += 0.02f;
            }
        }
        else {
            if (lights.intensity >= 0f)
            {
                lights.intensity -= 0.01f;
            }
        }
	}
}
