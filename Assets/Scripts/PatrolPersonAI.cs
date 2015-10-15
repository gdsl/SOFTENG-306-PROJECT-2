using UnityEngine;
using System.Collections;
/**
    Script which controls the Person behaviour. "Brain" script. Responsible for getting input from other scripts and acting.

    Patrol Person may be in two states.

    1. Patrolling
    2. Pointing (Santa found)
*/

public class PatrolPersonAI : MonoBehaviour
{

    // Set speeds for different movement types
    public float patrolSpeed = 3f;
    public float suspicionSpeed = 5f;

    // There will be wait times associated with certain movements
    public float patrolWaitTime = 5f;
    public float suspicionCheckWaitTime = 7f;

    public Transform[] patrolWayPoints;
    public Transform[] suspicionWayPoints;

    // Reference to several scripts
    private PersonSight personSight;
    private Suspicion suspicion;
    private Woken woken;
    private NavMeshAgent nav;
    private Transform santa;
    private GameController gameController;

    private GameObject touchObject;

    private float patrolTimer;
    private float suspicionTimer;
    private int patrolWayPointIndex;
    private int suspicionWayPointIndex;

    // initialize variables with awake function
    void Awake()
    {
        touchObject = this.transform.FindChild("SenseTouch").gameObject;
        suspicion = GetComponent<Suspicion>();
        personSight = GetComponent<PersonSight>();
        woken = touchObject.GetComponent<Woken>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Player").transform;
        gameController = GetComponent<GameController>();
    }

    /**
        Method called at each frame. Will call each of the below functions depending on current person "state"
        State checking has priority levels. Ordered from highest precedence to lowest
        1. Pointing
        2. Patrolling
    */

    void Update()
    {
        // When game controller triggers event for suspicion

        //if (true)
        //{
        //    // TODO. Condition should be replaced with GameController trigger action
        //}


        if (woken.woken)
        {
            // Santa is in sight. Point at santa
            Woken();
        } else if (personSight.santaInSight)
        {
            // Santa is in sight. Point at santa
            Pointing();
        } else if (suspicion.suspicionCheck)
        {
            Suspicion();
        }
        else
        {
            // Santa is not in sight. Just patrol area
            Patrolling();
        }
    }

	IEnumerator PersonSeen()
	{
		yield return new WaitForSeconds(2.0f);
		SuspicionController slider = GameObject.FindGameObjectWithTag("SuspicionSlider").GetComponent<SuspicionController>();
		slider.IncreaseSuspicionByAmount(5000);
	}

	void Suspicion()
    {
        // Set speed for NavMeshAgent
        nav.speed = suspicionSpeed;

        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            suspicionTimer += Time.deltaTime;

            if (suspicionTimer >= suspicionCheckWaitTime)
            {
                // It has reached its destination
                if (suspicionWayPointIndex == suspicionWayPoints.Length - 1)
                {
                    suspicionWayPointIndex = 0;
                    suspicion.suspicionCheck = false;
                    suspicion.look = true;
                }
                else
                {
                    suspicionWayPointIndex++;
                }

                suspicionTimer = 0f;
            }
        }
        else
        {
            suspicionTimer = 0f;
        }

        // Set the destination to the suspicionWayPoint
        nav.destination = suspicionWayPoints[suspicionWayPointIndex].position;

        // Resume movement if it has been stopped
        nav.Resume();
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

    void Patrolling()
    {
        // Set speed for NavMeshAgent
        nav.speed = patrolSpeed;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= patrolWaitTime)
            {
                if (patrolWayPointIndex == patrolWayPoints.Length - 1)
                {
                    patrolWayPointIndex = 0;
                }
                else
                {
                    patrolWayPointIndex++;
                }

                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
        }

        // Set the destination to the patrolWayPoint
        nav.destination = patrolWayPoints[patrolWayPointIndex].position;

        // Resume movement if it has been stopped
        nav.Resume();
    }

}
