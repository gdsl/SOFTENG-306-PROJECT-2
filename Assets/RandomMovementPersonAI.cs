using UnityEngine;
using System.Collections;

public class RandomMovementPersonAI : MonoBehaviour {

    public float walkRadius = 5f;
    public float randomMovementSpeed = 7f;
    public float randomMovementWaitTime = 1f;

    public float suspicionSpeed = 5f;
    public float suspicionCheckWaitTime = 7f;

    public Transform[] suspicionWayPoints;

    private PersonSight personSight;
    private Suspicion suspicion;
    private NavMeshAgent nav;
    private Transform santa;

    private float randomMovementTimer;
    private float suspicionTimer;
    private int suspicionWayPointIndex;

    private Vector3 startingPosition;

    // Use this for initialization
    void Awake()
    {
        suspicion = GetComponent<Suspicion>();
        personSight = GetComponent<PersonSight>();
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Player").transform;
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (personSight.santaInSight)
        {
            // Santa is in sight. Point at santa
            Pointing();
        }
        else if (suspicion.suspicionCheck)
        {
            Suspicion();
        }
        else
        {
            // Santa is not in sight. Just randomly move area
            RandomMove();
        }
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

    void RandomMove()
    {
        // set speed of character
        nav.speed = randomMovementSpeed;

        // initially enters loop
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            // reached destination
            randomMovementTimer += Time.deltaTime;

            if (randomMovementTimer >= randomMovementWaitTime)
            {
                // generate new path
                Vector3 dest = generateGoal();
                nav.destination = dest;

                randomMovementTimer = 0f;
            }
        }
        else
        {
            randomMovementTimer = 0f;
        }

        nav.Resume();
    }


    /**
        Finds random position around walk radius.
        http://answers.unity3d.com/questions/475066/how-to-get-a-random-point-on-navmesh.html
    */
    private Vector3 generateGoal()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += startingPosition;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);

        return hit.position;
    }
}
