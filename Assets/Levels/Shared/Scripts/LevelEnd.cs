using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    private GameObject player;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player) {
            Debug.Log("Delievereds");
            Application.LoadLevel("EndLevel");
        }
    }
}
