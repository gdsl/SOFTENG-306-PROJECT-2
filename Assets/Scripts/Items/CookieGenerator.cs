using UnityEngine;
using System.Collections;

public class CookieGenerator : MonoBehaviour {

    public Vector3[] locations;
    public int cookieCount;
    public GameObject cookie;
    private int remainingSize;

    void Awake() {

        if(cookieCount > locations.Length){
            cookieCount = locations.Length;
        }

        remainingSize = locations.Length;

        for (int i = 0; i < cookieCount; i++) {
            int index =(int) (Random.value * locations.Length);
            Vector3 location = locations[index];
            for( int j = index; j < remainingSize -1; j++ ){
                locations[j] = locations[j+1];
            }
            remainingSize--;

            Instantiate(cookie, location, Quaternion.identity);
        }
    }
}
