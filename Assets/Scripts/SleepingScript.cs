using UnityEngine;
using System.Collections;

public class SleepingScript : MonoBehaviour {

    public bool sleeping;

    private Animator anim;
    private PersonSight personSight;

    // Use this for initialization
    void Start () {
        // initially true
        sleeping = true;

        anim = GetComponent<Animator>();
        personSight = GetComponent<PersonSight>();
    }
	
	// Update is called once per frame
	void Update () {
        personSight.checkVision = !sleeping;
        anim.SetBool("Sleeping", sleeping);
	}
}
