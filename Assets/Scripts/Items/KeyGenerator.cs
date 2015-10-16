using UnityEngine;
using System.Collections;

public class KeyGenerator : MonoBehaviour {

    public Vector3[] fixedPositions;
    public Vector3[] randomLocations;
    public int keyCount;
    public GameObject key;
    private int remainingSize;
    private Vector3[] randomLocationsMod;

    void Awake()
    {
        generateKey();
    }

    public GameObject generateKey()
    {
        GameObject generatedKey = null;//key object generated
        for (int i = 0; i < fixedPositions.Length; i++)
        {
            Instantiate(key, fixedPositions[i], Quaternion.identity);
        }


        if (keyCount > randomLocations.Length)
        {
            keyCount = randomLocations.Length;
        }

        remainingSize = randomLocations.Length;
        randomLocationsMod = new Vector3[remainingSize];
        for (int k = 0; k < remainingSize; k++)//copy vector
        {
            randomLocationsMod[k] = randomLocations[k];
        }
        for (int i = 0; i < keyCount; i++)
        {
            int index = (int)(Random.value * remainingSize);
            Vector3 location = randomLocationsMod[index];
            for (int j = index; j < remainingSize - 1; j++)
            {
                randomLocationsMod[j] = randomLocationsMod[j + 1];
            }
            remainingSize--;
            generatedKey = (GameObject)Instantiate(key, location, Quaternion.identity);
        }
        return generatedKey;
    }
}
