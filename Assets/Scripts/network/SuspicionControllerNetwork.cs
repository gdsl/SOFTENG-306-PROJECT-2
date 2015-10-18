using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SuspicionControllerNetwork : SuspicionController
{

    public override void IncreaseSuspicionByAmount(float amount)
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        suspicionSlider.value = suspicionSlider.value + amount;
        if (suspicionSlider.value >= suspicionSlider.maxValue)
        {
            if (PlayerPrefs.GetInt("vibrate") == 1)
            {
                Handheld.Vibrate();
            }
            suspicionSlider.value = 0;
            santa.transform.position = NetworkManager.singleton.GetStartPosition().position;
            //GetComponent<NetworkTransform>().SetDirtyBit(1);
            santa.GetComponent<PlayerInventory>().SetCookieCount(0);
        }
    }

}
