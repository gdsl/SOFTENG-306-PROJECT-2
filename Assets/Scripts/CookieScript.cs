using UnityEngine;
using System.Collections;

public class CookieScript : MonoBehaviour {
    private bool isPickedUp=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isPickedUp)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isPickedUp = true;
        }
    }
}
