using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public GameObject DestroyedObject;
	public SuspicionController suspicionController;

    private BoxCollider collider;
    private AlertEnemy alert;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        if (collider)
        {
            collider.center = transform.GetComponent<MeshFilter>().mesh.bounds.center;
            collider.size = transform.GetComponent<MeshFilter>().mesh.bounds.size;
        }
        alert = GetComponent<AlertEnemy>();
    }

    // Updated so that it breaks on contact
	
	void OnCollisionEnter( Collision collision )
    {
		if( collision.relativeVelocity.magnitude > 1f) {
		    DestroyIt();
		}
	}
	
	void DestroyIt(){

        // Alert enemies
        if (alert != null)
            alert.Alert();

        //raise suspicion
        if (suspicionController != null)
            suspicionController.IncreaseSuspicionByAmount(1000);

		if(DestroyedObject) {
			Instantiate(DestroyedObject, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}