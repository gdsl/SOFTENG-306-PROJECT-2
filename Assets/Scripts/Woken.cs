using UnityEngine;
using System.Collections;

public class Woken : MonoBehaviour
{

    // Number of degrees, centred on the forward position, player can see.Default value of 110 degrees
    public bool woken;

    // Size of the game object's mesh
    //public Vector3 size;

    private GameObject parentObject;

    // Access to GameController script. This keeps track of the global last known location of Santa
    private GameController gameController;
    // Reference animator for this animator controller
    private Animator anim;
    private NavMeshAgent nav;
    private BoxCollider col;

    // Reference to Santa
    private GameObject santa;
    // Reference to Santa's state to know which state Santa is currently in. MIGHT NOT BE NEEDED
    private Animator santaAnim;

    // Use this for initialization
    void Start()
    {
        // initialize variables
        //size = GetComponent<Renderer>().size;

        // initially false
        woken = false;

        parentObject = this.transform.parent.gameObject;
        gameController = parentObject.GetComponent<GameController>();
        anim = parentObject.GetComponent<Animator>();
        nav = parentObject.GetComponent<NavMeshAgent>();
        col = GetComponent<BoxCollider>();

        // Get reference to Santa
        santa = GameObject.FindWithTag("Player");
        santaAnim = santa.GetComponent<Animator>();

    }

    // Update is called once per frame. Should call in this method information such as movement, triggering actions or responding to user input
    void Update()
    {

        // Call update to suspicion meter if santa hits the AI
        if (woken)
        {
            // Set the animator parameter "Woken" to whether if santa has hit the AI.
            anim.SetBool("Woken", woken);

            StartCoroutine(PersonSeen());

        }
    }

    // Satisfies if the colliding game object is Santa.
    // Called automatically when colliders touching the trigger
    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
            //if (other.gameObject == santa)
        {
            woken = true;
        }
    }

    // When santa leaves person's radius
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == santa)
        {
            woken = false;
        }
    }

    // Trigger suspicion meter update
    IEnumerator PersonSeen()
    {
        yield return new WaitForSeconds(3.0f);
        SuspicionController slider = GameObject.FindGameObjectWithTag("SuspicionSlider").GetComponent<SuspicionController>();
        slider.IncreaseSuspicionByAmount(5000);
    }
}
