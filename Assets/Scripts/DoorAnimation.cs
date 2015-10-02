using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
    private bool isLocked=true;
    private Animator animator;
    private GameObject player;                      // Reference to the player.
    private PlayerInventory playerInventory;        // Reference to the player's inventory.
    private int id = 1; //id of the door
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
        Debug.Log(other.name);
        // If the triggering gameobject is the player...
        if (other.gameObject == player)
        {
            // ... if this door requires a key...
            if (isLocked)
            {
                // ... if the player has the key...
                if (playerInventory.hasKey(id)){
                    // ... increase the count of triggering objects.
                    count++;
                }
            }
            else
	        {
                // If the door doesn't require a key, increase the count of triggering objects.
                count++;
                            }
        }
    }


    void Update()
    {
        // Set the open parameter.
        animator.SetBool(Animator.StringToHash("Open"), count > 0);


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
