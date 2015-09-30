using UnityEngine;

/**
    Script which controls the Person behaviour. "Brain" script. Responsible for getting input from other scripts and acting.

    Person may be in two states.

    1. Sleeping
        1.1 Sleep walking
    2. Awake
        2.1 Random movement
        2.2 Patrolling
        2.3 Suspicion check
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
    private NavMeshAgent nav;
    private Transform santa;
    private GameController gameController;
    private float patrolTimer;
    private float suspicionTimer;
    private int wayPointIndex;

    // initialize variables with awake function
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        santa = GameObject.FindGameObjectWithTag("Santa").transform;
        gameController = GetComponent<GameController>();
    }

    /**
        Method called at each frame. Will call each of the below functions depending on current person "state"
        State checking has priority levels. Ordered from highest precedence to lowest
        1. Suspicion Check
        2. Sleeping
        3. SleepWalking
        4. Patrolling
        5. RandomMovement
    */

    void Update()
    {
        // When game controller triggers event for suspicion

        //if (true)
        //{
        //    // TODO. Condition should be replaced with GameController trigger action
        //}
    }

    // 
    void SuspicionCheck()
    {

    }

    void Sleeping()
    {

    }

    void SleepWalking()
    {

    }

    void Patrolling()
    {

    }

    void RandomMovement()
    {

    }

}
