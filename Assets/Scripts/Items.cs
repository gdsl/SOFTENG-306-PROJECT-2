using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {
    private GameObject player;                      // Reference to the player.
    private PlayerInventory playerInventory;        // Reference to the player's inventory.
    private bool isPickedUp = false;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Destroy(gameObject);
        }
    }
	
    public GameObject getPlayer(){
        return player;
    }

    public PlayerInventory getPlayerInventory()
    {
        return playerInventory;
    }

    public void setPickedUp()
    {
        isPickedUp=true;
    }
}
