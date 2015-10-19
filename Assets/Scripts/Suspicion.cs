using UnityEngine;
using System.Collections;

public class Suspicion : MonoBehaviour {

    // Animator values
    public bool look;
    public bool suspicionCheck;

    private Animator anim;

	// Use this for initialization
	void Start () {
        // initally values false
        look = false;
        suspicionCheck = false;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // Trigger looking
        if (look)
        {
            anim.SetTrigger("Look");
            suspicionCheck = false;
            look = false;
        }
    }
}
