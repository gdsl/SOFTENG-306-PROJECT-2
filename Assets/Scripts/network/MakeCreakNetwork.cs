﻿using UnityEngine;
using System.Collections;

public class MakeCreakNetwork : MonoBehaviour {

    private GameObject[] enemies;
    private Vector2 boardPosition;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boardPosition = new Vector2(transform.position.x, transform.position.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //play the creaky floorboard audio
            AudioSource creakyAudio = GameObject.FindGameObjectWithTag("CreakyAudio").GetComponent<AudioSource>();
            creakyAudio.Play();
            //raise the suspicion level
            SuspicionController slider = other.gameObject.GetComponent<SuspicionControllerNetwork>();
            slider.IncreaseSuspicionByAmount(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 300);
            //notify all human game objects that a creaky floorboard has been stepped on
            //it is up to them to figure out if they heard the sound
            //data sent is the vector3 position of the floorboard stepped on
            AlertEnemy alert = GetComponent<AlertEnemy>();
            alert.Alert();
        }
    }
}
