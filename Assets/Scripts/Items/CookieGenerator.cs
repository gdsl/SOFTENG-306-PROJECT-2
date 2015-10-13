using UnityEngine;
using System.Collections;

public class CookieGenerator : MonoBehaviour {

    public Vector3[] fixedPositions;
    public Vector3[] randomLocations;
    public int cookieCount;
    public GameObject cookie;
    private int remainingSize;

    void Awake() {
        for (int i = 0; i < fixedPositions.Length; i++) {
            Instantiate(cookie, fixedPositions[i], Quaternion.identity);
        }


            if (cookieCount > randomLocations.Length)
            {
                cookieCount = randomLocations.Length;
            }

        remainingSize = randomLocations.Length;

        for (int i = 0; i < cookieCount; i++) {
            int index =(int) (Random.value * remainingSize);
            Vector3 location = randomLocations[index];
            for( int j = index; j < remainingSize -1; j++ ){
                randomLocations[j] = randomLocations[j+1];
            }
            remainingSize--;
            Instantiate(cookie, location, Quaternion.identity);
        }
    }
}
