using UnityEngine;
using System.Collections;

public class SleepingPersonAI : MonoBehaviour
{

    public float speed = 2f;
    public float waitTime = 3f;
    public Transform[] walkPoints;

    private SleepingScript sleepingScript;
    private PersonSight personSight;
    private Suspicion suspicion;
    private NavMeshAgent nav;
    private Transform santa;
    private FOV2DEyes fovEyesScript;
    private FOV2DVisionCone fovConeScript;
    private float timer;
    private int wayPointIndex;
    private bool direction;

    private GameObject touchObject;
    private Woken woken;


    // Use this for initialization
    void Awake()
    {
        // Setting up the reference
        sleepingScript = GetComponent<SleepingScript>();
        personSight = GetComponent<PersonSight>();
        suspicion = GetComponent<Suspicion>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Player").transform;
        fovEyesScript = GetComponent<FOV2DEyes>();
        fovConeScript = GetComponent<FOV2DVisionCone>();

        touchObject = this.transform.FindChild("SenseTouch").gameObject;
        woken = touchObject.GetComponent<Woken>();

    }

    // Update is called once per frame
    void Update()
    {
        if (sleepingScript.sleeping)
        {
            fovEyesScript.enabled = false;
            fovConeScript.enabled = false;
            Sleeping();
        }
        else if (woken.woken)
        {
            Woken();
        }
        else if (personSight.santaInSight)
        {
            if (fovEyesScript.enabled == false)
            {
                fovEyesScript.enabled = true;
                fovConeScript.enabled = true;
            }
            Pointing();
        }
        else
        {
            if (fovEyesScript.enabled == false)
            {
                fovEyesScript.enabled = true;
                fovConeScript.enabled = true;
            }
            Suspicion();
        }
    }

    // Basically tells Nav Mesh Agent to stop at its spot
    void Sleeping()
    {
        nav.Stop();
    }

    void Pointing()
    {
        // Stop the character where it is
        nav.Stop();
    }

    void Woken()
    {
        // Stop the character where it is
        nav.Stop();
    }

    void Suspicion()
    {
        // Set speed for NavMeshAgent
        nav.speed = speed;

        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {

                if (wayPointIndex == walkPoints.Length - 1)
                {
                    suspicion.suspicionCheck = false;
                    suspicion.look = true;
                }
                else if (wayPointIndex == 0 && suspicion.suspicionCheck == false)
                {
                    // Returned back to bed. Return to sleep
                    sleepingScript.sleeping = true;
                }

                // Sleeping Person is going to check for Santa. Increment to go to looking point
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
