using UnityEngine;

/**
    Script which controls the Person behaviour. "Brain" script. Responsible for getting input from other scripts and acting.

    Patrol Person may be in two states.

    1. Patrolling
    2. Pointing (Santa found)
*/

public class PersonAI : MonoBehaviour
{

    // Set speeds for different movement types
    public float patrolSpeed = 3f;
    public float suspicionSpeed = 5f;

    // There will be wait times associated with certain movements
    public float patrolWaitTime = 5f;
    public float suspicionCheckWaitTime = 7f;

    public Transform[] patrolWayPoints;

    // Reference to several scripts
    private PersonSight personSight;
    private NavMeshAgent nav;
    private Transform santa;
    private GameController gameController;
    private float patrolTimer;
    private float suspicionTimer;
    private int wayPointIndex;

    // initialize variables with awake function
    void Awake()
    {
        personSight = GetComponent<personSight>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Santa").transform;
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

        if (personSight.santaInSight)
        {
            // Santa is in sight. Point at santa
            Pointing();
        }
        else
        {
            // Santa is not in sight. Just patrol area
            Patrolling();
        }
    }

    void Pointing()
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
                if (wayPointIndex == patrolWayPoints.Length - 1)
                {
                    wayPointIndex = 0;
                }
                else
                {
                    wayPointIndex++;
                }

                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
        }

        // Set the destination to the patrolWayPoint
        nav.destination = patrolWayPoints[wayPointIndex].position;
    }

}
