using UnityEngine;
using System.Collections;

public class SleepingScript : MonoBehaviour {

    public bool sleeping;

    private Animator anim;

    // Use this for initialization
    void Start () {
        // initially true
        sleeping = true;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Sleeping", sleeping);
	}
}
