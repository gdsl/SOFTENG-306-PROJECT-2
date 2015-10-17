using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuspicionControllerNetwork : MonoBehaviour {
    public GameObject santa;
    public Slider suspicionSlider;
    public GameObject failScreen;
    public GameObject successScreen;
    public Text failText;

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
        if (failScreen.activeInHierarchy || successScreen.activeInHierarchy || Time.deltaTime == 0)
        {
            return;
        }
        //Debug.LogError ("lol");
        suspicionSlider.value = suspicionSlider.value + amount;
        if (suspicionSlider.value >= suspicionSlider.maxValue)
        {

            if (!successScreen.active)
            {
                santa.GetComponent<PlayerNetwork>().MaxSuspicion();
            }
        }
    }

}
