using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class makeCreak : MonoBehaviour {

	private GameObject player;
	private GameObject[] enemies;
    private Vector2 boardPosition;


    void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boardPosition = new Vector2(transform.position.x, transform.position.y);
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject == player) {
            //raise the suspicion level
            SuspicionController slider = GameObject.FindGameObjectWithTag("SuspicionSlider").GetComponent<SuspicionController>();
            //slider.IncreaseSuspicionByAmount(player.velocity);
            //notify all human game objects that a creaky floorboard has been stepped on
            //it is up to them to figure out if they heard the sound
            //data sent is the vector3 position of the floorboard stepped on
            foreach (GameObject enemy in enemies) {
                //ExecuteEvents.Execute<FloorboardMessage>(enemy, transform.position, (x,y)=>x.receiveFloorboardMessage());
                Vector2 enemyXY = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
                Vector2 difference = boardPosition - enemyXY;

                if (Mathf.Abs(difference.x) <= 6.5)
                {
                    if (Mathf.Abs(difference.y) <= 6.5)
                    {
                        SleepingScript script = enemy.GetComponent<SleepingScript>();
                        script.sleeping = false;
                    }
                }
            }
		}
	}
}
