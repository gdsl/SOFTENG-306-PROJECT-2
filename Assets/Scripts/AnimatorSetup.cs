using UnityEngine;
using System.Collections;
/*
    Helper Script used to dampen Animation.
    This is not attached to a Game Object therefore is not a subclass of MonoBehaviour so there is no awake/update/start methods.
    Sometimes, movement is sudden, resulting in unrealistic animation movement, use this class to smooth the animation transition
*/

public class AnimatorSetup
{
    // Default values. CAN BE CHANGED
    // Damping times for speed and angular speed
    public float speedDampTime = 0.1f;
    public float angularSpeedDampTime = 0.7f;
    // Response time to convert angle to angular speed
    public float angleResponseTime = 0.6f;

    private AnimatorSetup anim;

    /**
        Public constructor which can be called be scripts which want to use the helper script
     */
    public AnimatorSetup(Animator anim)
    {
        this.anim = anim;
    }

    /*
        To apply damping and set speed and angular speed in the animator
    */
    public void Setup(float speed, float angle)
    {
        // Need to create angular speed which will be passed to the animator controller. This is the angle by which the player should turn divied by response time
        float angularSpeed = angle / angleResponseTime;

        anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
        anim.SetFloat("AngularSpeed", angularSpeed, angularSpeedDampTime, Time.deltaTime);
    }
}
