using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MakeCreak : MonoBehaviour {

    public float radius;

	private GameObject player;
	private GameObject[] enemies;
    private Vector2 boardPosition;


    void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boardPosition = new Vector2(transform.position.x, transform.position.y);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
            //raise the suspicion level
            SuspicionController slider = GameObject.FindGameObjectWithTag("SuspicionSlider").GetComponent<SuspicionController>();
			slider.IncreaseSuspicionByAmount(player.GetComponent<Rigidbody> ().velocity.magnitude);
            //notify all human game objects that a creaky floorboard has been stepped on
            //it is up to them to figure out if they heard the sound
            //data sent is the vector3 position of the floorboard stepped on

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            foreach(Collider collider in hitColliders)
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

            //foreach (GameObject enemy in enemies) {
            //    //ExecuteEvents.Execute<FloorboardMessage>(enemy, transform.position, (x,y)=>x.receiveFloorboardMessage());
            //    Vector2 enemyXY = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
            //    Vector2 difference = boardPosition - enemyXY;

            //    // Debugging purposes
            //    SleepingScript script = enemy.GetComponent<SleepingScript>();
            //    Suspicion suspicion = enemy.GetComponent<Suspicion>();
            //    if (script != null)
            //    {
            //        script.sleeping = false;
            //    }
            //    suspicion.suspicionCheck = true;
            //    Debug.Log("Triggered");

            //    //if (Mathf.Abs(difference.x) <= 6.5)
            //    //{
            //    //    if (Mathf.Abs(difference.y) <= 6.5)
            //    //    {
            //    //        SleepingScript script = enemy.GetComponent<SleepingScript>();
            //    //        script.sleeping = false;
            //    //        Debug.Log("Triggered");
            //    //    }
            //    //}
            //}
        }
	}
}
