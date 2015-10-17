using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SuspicionControllerNetwork : NetworkBehaviour
{
    public GameObject santa;
    public Slider suspicionSlider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (santa.GetComponent<Rigidbody>().velocity.magnitude > 0.2)
        {
            //Debug.Log(santa.GetComponent<Rigidbody>().velocity.magnitude);
            IncreaseSuspicionByAmount(santa.GetComponent<Rigidbody>().velocity.magnitude);
        }
    }

    void IncreaseSuspicion()
    {
        IncreaseSuspicionByAmount(1);
    }

    public void IncreaseSuspicionByAmount(float amount)
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        suspicionSlider.value = suspicionSlider.value + amount;
        if (suspicionSlider.value >= suspicionSlider.maxValue)
        {
            Handheld.Vibrate(); 
            suspicionSlider.value = 0;
            santa.transform.position = NetworkManager.singleton.GetStartPosition().position;
            //GetComponent<NetworkTransform>().SetDirtyBit(1);
            santa.GetComponent<PlayerInventory>().SetCookieCount(0);
        }
    }

}
