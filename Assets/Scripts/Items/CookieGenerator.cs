using UnityEngine;
using System.Collections;

public class CookieGenerator : MonoBehaviour {

    public Vector3[] fixedPositions;
    public Vector3[] randomLocations;
    public int cookieCount;
    public GameObject cookie;
    private int remainingSize;
    private Vector3[] randomLocationsMod;

    void Awake() {
        generateCookie();
    }

    public GameObject generateCookie()
    {
        GameObject generatedCookie=null;//cookie object generated
        for (int i = 0; i < fixedPositions.Length; i++)
        {
            Instantiate(cookie, fixedPositions[i], Quaternion.identity);
        }


        if (cookieCount > randomLocations.Length)
        {
            cookieCount = randomLocations.Length;
        }

        remainingSize = randomLocations.Length;
        randomLocationsMod = new Vector3[remainingSize];
        for (int k=0; k < remainingSize; k++)//copy vector
        {
            randomLocationsMod[k] = randomLocations[k];
        }
        for (int i = 0; i < cookieCount; i++)
        {
            int index = (int)(Random.value * remainingSize);
            Vector3 location = randomLocationsMod[index];
            for (int j = index; j < remainingSize - 1; j++)
            {
                randomLocationsMod[j] = randomLocationsMod[j + 1];
            }
            remainingSize--;
            generatedCookie =(GameObject) Instantiate(cookie, location, Quaternion.identity);
        }
        return generatedCookie;
    }
}
