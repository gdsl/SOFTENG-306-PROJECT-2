using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour
{
    float blinkDurationSecs = 1f;
    float blinkProgress = 0f;
    float blinkStep = 0.01f;
    //Color txtColor = Color.black;
    public Text blinkingText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((blinkProgress > 1) || (blinkProgress < 0))
        {
            blinkStep *= -2f;
        }
        blinkProgress += blinkStep;
        blinkingText.color = Color.Lerp(Color.black, Color.white, blinkProgress);// or whatever color you choose
    }
}
