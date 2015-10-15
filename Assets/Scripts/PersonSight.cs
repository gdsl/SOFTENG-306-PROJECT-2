using System.Collections;
using UnityEngine;

/*
    Script which controls person's FOV in the game and reacts to what it sees. Can be used for any type of person
    Dependency:
    1. GameController (Santa)
    2. Animation (Animator Controller). To control animations of character
*/

public class PersonSight : MonoBehaviour {

    // Number of degrees, centred on the forward position, player can see. Default value of 110 degrees
    public float fieldOfViewAngle = 110f;
    public bool santaInSight;

    // Criteria to check raycast
    public bool checkVision;

    // Access to GameController script. This keeps track of the global last known location of Santa
    private GameController gameController;
    // Reference animator for this animator controller
    private Animator anim;
    private NavMeshAgent nav;
    private SphereCollider col;

    // Reference to Santa
    private GameObject santa;
    // Reference to Santa's state to know which state Santa is currently in. MIGHT NOT BE NEEDED
    private Animator santaAnim;

    // Layer to ignore during raycast
    private int layerMask;

    // Use this for initialization
    void Start () {
        // initialize variables
        //size = GetComponent<Renderer>().size;

        // initially false
        santaInSight = false;

        gameController = GetComponent<GameController>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();

        // Get reference to Santa
        santa = GameObject.FindWithTag("Player");
        santaAnim = santa.GetComponent<Animator>();

        // initially set vision to true
        checkVision = true;

        // Ignore layer 2. Layer 2 is default layer provided by unity which is Ignore Raycast
        layerMask = 1 << 2;
        layerMask = ~layerMask;
    }
	
	// Update is called once per frame. Should call in this method information such as movement, triggering actions or responding to user input
	void Update () {
        // Set the animator parameter "SantaInSight" to whether if santa is currently in sight.
        anim.SetBool("SantaInSight", santaInSight);

        // Call update to suspicion meter if santa is seen
        if (santaInSight)
            StartCoroutine(PersonSeen());
    }

    /*
        For santaInSight to be true, it must satisfy THREE conditions.
        1. Santa is within the trigger zone
        2. Santa is in front of the person
        3. Nothing is preventing the person from seeing Santa
    */

    // Satisfies if the colliding game object is Santa.
    // Called automatically when colliders touching the trigger
    void OnTriggerStay(Collider other)
    {
        // Check if the colliding object is santa
        if (other.gameObject == santa && checkVision == true)
        {
            // Satisfies first condition. Must check if it satisfies other condition
            // Initially default santaInSight to false
            santaInSight = false;

            // Determine if player is within field of view, use function called Angle. This takes in two vector3 and return angle between them
            // Inputs:
            // 1. Vector to Santa
            // 2. Person's forward vector
            // If this angle is less than half the field of view angle then santa is within the view

            // Vector to santa
            Vector3 direction = other.transform.position - transform.position;

            // Angle between two values
            float angle = Vector3.Angle(direction, transform.forward);

            // Check if angle is less than half the field of view angle of person's field of vision
            if (angle < fieldOfViewAngle * 0.5f)
            {
                // Check if there is obstruction between santa and person which will hide santa
                RaycastHit hit;

                // View of ray cast ground level transform.position
                // Direction vector of ray cast is always normalized (0-1)
                // Ray cast distance being the radius of the collider
                if (Physics.Raycast(transform.position, direction.normalized, out hit, col.radius, layerMask))
                {
                    if (hit.collider.gameObject == santa)
                    {
                        santaInSight = true;
                    }
                }
            }

        }
    }

    // When santa leaves person's radius
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == santa)
        {
            santaInSight = false;
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
