using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
    public bool isLocked=true;
    private Animator animator;
    private GameObject player;                      // Reference to the player.
    private PlayerInventory playerInventory;        // Reference to the player's inventory.
    public int id; //id of the door
    private int count;

    void Awake()
    {
        // Setting up the references.
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the triggering gameobject is the player...
        if (other.gameObject == player)
        {
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
            count++;
        }
    }


    void Update()
    {
        // Set the open parameter.
            animator.SetBool(Animator.StringToHash("ClosetDoorOpen"), count > 0);
            animator.SetBool(Animator.StringToHash("DoorOpen"), count > 0);
    }

    void OnTriggerExit(Collider other)
    {
        // When player leave the door region the 
        if (other.gameObject == player)
        {
            Debug.Log(other.name);
            // decrease the count of triggering objects.
            count = Mathf.Max(0, count - 1);
        }
    }

}
