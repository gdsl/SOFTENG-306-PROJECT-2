using UnityEngine;
using System.Collections;

/**
    AI script for Sitting people. Switches animation between sitting and suspicion checking
*/
public class SittingPersonAI : MonoBehaviour {

    public float speed = 2f;
    public float waitTime = 3f;
    public Transform[] walkPoints;
    public Transform refPoint;

    public float sittingFOV = 80f;

    private SittingScript sittingScript;
    private PersonSight personSight;
    private Suspicion suspicion;
    private NavMeshAgent nav;
    private Transform santa;
    private float timer;
    private int wayPointIndex;
    private bool direction;

    private float originalFOV;

    private Woken woken;
    private GameObject touchObject;

    // Use this for initialization
    void Awake ()
    {
        // Setting up the reference
        sittingScript = GetComponent<SittingScript>();
        personSight = GetComponent<PersonSight>();
        suspicion = GetComponent<Suspicion>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Player").transform;
        originalFOV = personSight.fieldOfViewAngle;

        touchObject = this.transform.FindChild("SenseTouch").gameObject;
        woken = touchObject.GetComponent<Woken>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (suspicion.suspicionCheck || personSight.santaInSight)
        {
            sittingScript.sitting = false;
        }

	    if (personSight.santaInSight)
        {
            Pointing();
        }
        else if (woken.woken)
        {
            Woken();
        }
        else if(sittingScript.sitting)
        {
            Sitting();
        }
        else
        {
            Suspicion();
        }
	}

    // Basically tells Nav Mesh Agent to stop at its spot
    void Sitting()
    {
        // change fov to smaller since person is more "focused"
        personSight.fieldOfViewAngle = sittingFOV;
        nav.Stop();
    }

    void Woken()
    {
        // Stop the character where it is
        nav.Stop();
    }

    void Pointing()
    {
        // Stop the character where it is
        nav.Stop();
    }

    void Suspicion()
    {
        // Change fov back to normal
        personSight.fieldOfViewAngle = originalFOV;

        // Set speed for NavMeshAgent
        nav.speed = speed;

        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {

                if (wayPointIndex == walkPoints.Length - 1)
                {
                    Debug.Log("hit");
                    suspicion.suspicionCheck = false;
                    suspicion.look = true;
                }
                else if (wayPointIndex == 0 && suspicion.suspicionCheck == false)
                {
                    Vector3 direction = refPoint.position - transform.position;
                    // Angle between two values
                    float angle = Vector3.Angle(direction, transform.forward);
                    transform.Rotate(0, angle + 180, 0, Space.Self);
                    // Returned back to bed. Return to sleep
                    sittingScript.sitting = true;
                }

                // Sitting Person is going to check for Santa. Increment to go to looking point
                if (suspicion.suspicionCheck)
                {
                    if (wayPointIndex < walkPoints.Length - 1)
                    {
                        wayPointIndex++;
                    }
                }
                else
                {
                    // Santa has finished checking for santa. Decrement to go back to bed
                    if (wayPointIndex != 0)
                    {
                        wayPointIndex--;
                    }
                }

                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }

        // Set the destination to the patrolWayPoint
        nav.destination = walkPoints[wayPointIndex].position;

        // Resume movement if it has been stopped
        nav.Resume();
    }
}
