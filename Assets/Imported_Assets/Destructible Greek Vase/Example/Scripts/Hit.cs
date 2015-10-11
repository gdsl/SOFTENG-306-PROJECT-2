using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	public GameObject DestroyedObject;

    // Updated so that it breaks on contact
	
	void OnCollisionEnter( Collision collision )
    {
		if( collision.relativeVelocity.magnitude > 2f) {
		    DestroyIt();
		}
	}
	
	void DestroyIt(){
		if(DestroyedObject) {
			Instantiate(DestroyedObject, transform.position, transform.rotation);
		}
		Destroy(gameObject);

	}
}