using UnityEngine;
using System.Collections;

public class SleepWalkerAI : MonoBehaviour {

    public float walkRadius = 5f;
    public float randomMovementSpeed = 2f;
    public float randomMovementWaitTime = 1f;

    private Woken woken;
    private NavMeshAgent nav;

    private float randomMovementTimer;

    private Vector3 startingPosition;

    // Use this for initialization
    void Awake()
    {
        woken = GetComponent<Woken>();
        nav = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (woken.woken)
        {
            // Santa is in sight. Point at santa
            Woken();
        }
        else
        {
            // Santa is not in sight. Just randomly move area
            RandomMove();
        }
    }


    void Woken()
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
