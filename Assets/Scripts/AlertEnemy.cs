using UnityEngine;
using System.Collections;

// Script which alerts enemies nearby of suspicion
public class AlertEnemy : MonoBehaviour {

    public float radius;

    // Called by other script. Calls nearby enemies and increases suspicion
    public void Alert()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                SleepingScript script = collider.gameObject.GetComponent<SleepingScript>();
                Suspicion suspicion = collider.gameObject.GetComponent<Suspicion>();
                if (script != null)
                {
                    script.sleeping = false;
                }
                suspicion.suspicionCheck = true;
            }
        }
    }
}
