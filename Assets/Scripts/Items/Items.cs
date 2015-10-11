using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {
    private bool isPickedUp = false;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // when item pick up destroy item
        if (isPickedUp)
        {
            Destroy(gameObject);
        }
    }

    public void setPickedUp()
    {
        isPickedUp=true;
    }
}
