﻿using UnityEngine;
using System.Collections;

public class ClosetAnimation : MonoBehaviour
{
    public bool isLocked = true;
    private Animator animator1;
    private Animator animator2;
    private GameObject player;                      // Reference to the player.
    private PlayerInventory playerInventory;        // Reference to the player's inventory.
    public int id; //id of the door
    private int count;

    public GameObject[] closets;

    void Awake()
    {
        animator1 = closets[0].GetComponent<Animator>();
        animator2 = closets[1].GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the triggering gameobject is the player...
        if (other.gameObject.tag == "Player")//only check if tag is player
        {
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            // ... if this door requires a key...
            if (isLocked)
            {
                // ... if the player has the key...
                if (playerInventory.hasKey(id))
                {
                    // ... increase the count of triggering objects.
                    count++;
                    //play door unlocked audio
                    AudioSource unlockAudio = GameObject.FindGameObjectWithTag("UnlockDoorAudio").GetComponent<AudioSource>();
                    unlockAudio.Play();
                }
            }
            else
            {
                // If the door doesn't require a key, increase the count of triggering objects.
                count++;
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            // If its people in the house they can open door
            if (other is CapsuleCollider)//Temporary fix for large collider opening doors
            {
                count++;
            }
        }
    }


    void Update()
    {
        // Set the open parameter.
        animator1.SetBool(Animator.StringToHash("ClosetDoorOpen"), count > 0);
        animator1.SetBool(Animator.StringToHash("DoorOpen"), count > 0);
        animator2.SetBool(Animator.StringToHash("ClosetDoorOpen"), count > 0);
        animator2.SetBool(Animator.StringToHash("DoorOpen"), count > 0);
    }

    void OnTriggerExit(Collider other)
    {
        // When player leave the door region the 
        if (other.gameObject.tag == "Player" || (other.gameObject.tag == "Enemy" && other is CapsuleCollider))
        {
            Debug.Log(other.name);
            // decrease the count of triggering objects.
            count = Mathf.Max(0, count - 1);
        }
    }

}