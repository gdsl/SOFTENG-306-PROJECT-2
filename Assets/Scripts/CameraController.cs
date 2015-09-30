using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject santa;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - santa.transform.position;
	}

    void LateUpdate() {
        transform.position = santa.transform.position + offset;
    }
}
