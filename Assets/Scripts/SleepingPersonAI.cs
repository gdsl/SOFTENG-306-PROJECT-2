using UnityEngine;
using System.Collections;

public class SleepingPersonAI : MonoBehaviour {

    public float speed = 2f;
    public float waitTime = 3f;
    public Transform[] walkPoints;

    private SleepingScript sleepingScript;
    private PersonSight personSight;
    private Suspicion suspicion;
    private NavMeshAgent nav;
    private Transform santa;
    private float timer;
    private int wayPointIndex;
    private bool direction;

	// Use this for initialization
    void Awake()
    {
        // Setting up the reference
        sleepingScript = GetComponent<SleepingScript>();
        personSight = GetComponent<PersonSight>();
        suspicion = GetComponent<Suspicion>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Santa").transform;
    }
	
	// Update is called once per frame
	void Update () {
	    if (sleepingScript.sleeping)
        {
            Sleeping();
        }
        else if (personSight.santaInSight)
        {
            Pointing();
        }
        else
        {
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

    void Suspicion()
    {
        // Set speed for NavMeshAgent
        nav.speed = speed;

        if (nav.remainingDistance < nav.stoppingDistance)
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
                    wayPointIndex++;
                }
                else
                {
                    // Santa has finished checking for santa. Decrement to go back to bed
                    wayPointIndex--;
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
