using UnityEngine;
using System.Collections;

public class Suspicion : MonoBehaviour {

    // Animator values
    public bool suspicion;
    public bool suspicionCheck;
    public bool suspicionCheckProgress;

    private Animator anim;

	// Use this for initialization
	void Start () {
        // initally values false
        suspicion = false;
        suspicionCheck = false;
        suspicionCheckProgress = false;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // Trigger suspicion
        if (suspicion)
        {
            anim.SetTrigger("Suspicion");
            suspicion = false;
            suspicionCheckProgress = true;
        }

        if (suspicionCheck)
        {
            anim.SetTrigger("SuspicionCheck");
            suspicionCheck = false;
        }
    }
}
