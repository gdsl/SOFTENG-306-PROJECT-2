using UnityEngine;
using System.Collections;

public class Woken : MonoBehaviour
{

    // Number of degrees, centred on the forward position, player can see.Default value of 110 degrees
    public float fieldOfViewAngle = 110f;
    public bool woken;

    // Size of the game object's mesh
    //public Vector3 size;

    // Access to GameController script. This keeps track of the global last known location of Santa
    private GameController gameController;
    // Reference animator for this animator controller
    private Animator anim;
    private NavMeshAgent nav;
    private CapsuleCollider col;

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

        gameController = GetComponent<GameController>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<CapsuleCollider>();

        // Get reference to Santa
        santa = GameObject.FindWithTag("Player");
        santaAnim = santa.GetComponent<Animator>();
    }

    // Update is called once per frame. Should call in this method information such as movement, triggering actions or responding to user input
    void Update()
    {
        // Set the animator parameter "SantaInSight" to whether if santa is currently in sight.
        anim.SetBool("Woken", woken);

        // Call update to suspicion meter if santa is seen
        if (woken)
            StartCoroutine(PersonSeen());
    }

    // Satisfies if the colliding game object is Santa.
    // Called automatically when colliders touching the trigger
    void OnTriggerStay(Collider other)
    {
        // Check if the colliding object is santa
        if (other.gameObject == santa)
        {
            // Satisfies first condition. Must check if it satisfies other condition
            // Initially default santaInSight to false
            woken = true;
        }
    }

    // When santa leaves person's radius
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == santa)
        {
            woken = false;
        }
    }

    // Person seen. Trigger suspicion meter update
    IEnumerator PersonSeen()
    {
        yield return new WaitForSeconds(3.0f);
        SuspicionController slider = GameObject.FindGameObjectWithTag("SuspicionSlider").GetComponent<SuspicionController>();
        slider.IncreaseSuspicionByAmount(5000);
    }
}
