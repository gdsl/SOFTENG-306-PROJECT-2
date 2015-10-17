using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public GameObject DestroyedObject;
	public SuspicionController suspicionController;

    private BoxCollider collider;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        if (collider)
        {
            collider.center = transform.GetComponent<MeshFilter>().mesh.bounds.center;
            collider.size = transform.GetComponent<MeshFilter>().mesh.bounds.size;
        }
    }

    // Updated so that it breaks on contact
	
	void OnCollisionEnter( Collision collision )
    {
		if( collision.relativeVelocity.magnitude > 1f && collision.gameObject.tag == "Player") {
		    DestroyIt();
		}
	}
	
	void DestroyIt(){
		if(DestroyedObject) {
			Instantiate(DestroyedObject, transform.position, transform.rotation);
		}
		Destroy(gameObject);

        // Alert enemies
        AlertEnemy alert = GetComponent<AlertEnemy>();
        alert.Alert();

		//raise suspicion
		suspicionController.IncreaseSuspicionByAmount (1000);
	}
}