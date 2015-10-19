using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Destroy());
	}

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
