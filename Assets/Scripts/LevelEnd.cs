using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    private GameObject player;
	public GameObject successScreen;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player) {
            Debug.Log("Delivered present to tree");
            //Application.LoadLevel("EndLevel");
			successScreen.SetActive(true);

        }
    }
}
