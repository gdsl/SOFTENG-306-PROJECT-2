using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
    public bool isLocked = true;
    private GameObject player;
    private PlayerInventory playerInventory;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col) {
        Quaternion rotation = Quaternion.Euler(0f, 110f, 0f);
        Quaternion current = transform.localRotation;
        transform.localRotation = Quaternion.Euler(0f, 110f, 0f);

    }
}
