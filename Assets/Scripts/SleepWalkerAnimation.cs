﻿using UnityEngine;
using System.Collections;

public class SleepWalkerAnimation : MonoBehaviour
{

    // Deadzone. Value range which should be ignored. Example if the difference in velocity and desired location is small.
    public float deadZone = 5f;

    // Reference to santa transform. Might not be needed
    private Transform santaTransform;

    // Reference to woken script
    private Woken woken;

    // Reference to child object which contains touch sensing
    private GameObject touchObject;

    // Needed to guide person's movement
    private NavMeshAgent nav;

    // Reference to animator controller for people
    private Animator anim;

    // Reference to helper class 
    private AnimatorSetup animSetup;

    void Awake()
    {
        touchObject = this.transform.FindChild("SenseTouch").gameObject;
        woken = touchObject.GetComponent<Woken>();
        santaTransform = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Must make sure rotation of person is by the animator and not by the nav mesh agent
        nav.updateRotation = false;
        animSetup = new AnimatorSetup(anim);

        // Convert deadZone variable from degrees to radians
        deadZone *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the parameters that need to be passed to the Person animator component
        NavAnimSetup();
    }

    // Most of the script is setting up the animations based on the nav mesh agent
    void NavAnimSetup()
    {
        // Will be passed into helper AnimatorSetup script
        float speed = 0f;
        float angle = 0f;

        if (woken.woken)
        {
            // If santa is in sight, we want person to stop.
            speed = 0f;

            // Angle difference between currently facing direction to where it should face (position of santa)
            angle = FindAngle(transform.forward, santaTransform.position - transform.position, transform.up);
        }
        else
        {
            // Santa is not in sight. The speed should be based on nav mesh agent's desired velocity.
            // Achieved by projection in order to project the desired velocity vector on to the person's forward vector
            speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;

            // angle between forward and the desired velocity
            angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);

            // Because we damp the animation parameters. When there is a turn, model will follow a snakey motion. Have to prevent this with a check
            if (Mathf.Abs(angle) < deadZone)
            {
                // Avoid using animator controller to set motion.
                // Set person's transform to look at the desired velocity from it's own position
                transform.LookAt(transform.position + nav.desiredVelocity);
                angle = 0f;
            }
        }

        // Call the Setup function of the helper AnimatorSetup script to give values to the Animator Controller
        animSetup.Setup(speed, angle);
    }

    /**
       toVector is nav mesh agent's desired velocity. The value sometimes equal zero. Have to check for this as it might cause error
   */
    float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
    {
        // If the vector the angle is being calculated to is 0..
        if (toVector == Vector3.zero)
        {
            // Direction should be zero
            // the angle between the Person and the toVector is zero
            return 0f;
        }

        // Find absolute value of the angle respective to forward vector
        float angle = Vector3.Angle(fromVector, toVector);

        // Determine if angle is to the left or right of the forward direction
        // Find the cross product of the two vectors (this will point up if the velocity is to the right of forward)
        Vector3 normal = Vector3.Cross(fromVector, toVector);
        angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
        angle *= Mathf.Deg2Rad;

        return angle;
    }
}
