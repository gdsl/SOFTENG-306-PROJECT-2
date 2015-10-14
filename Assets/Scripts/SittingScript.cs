using UnityEngine;
using System.Collections;

public class SittingScript : MonoBehaviour {

    public bool sitting;

    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        sitting = true;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("Sitting", sitting);
    }
}
