using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkCookieManager : MonoBehaviour {

    public List<Vector3> spawnPoints = new List<Vector3>();
    public Dictionary<Vector3, GameObject> currentCookieMap = new Dictionary<Vector3, GameObject>();
    public GameObject cookiePrefab;
    public int maximumCookies = 2;
    private int currentCookies = 0;

	// Use this for initialization
	void Start () {
	
	}

    void Awake() {
        generateCookies();
    }
	
	// Update is called once per frame
	void Update () {
        removeDeletedCookies();
        generateCookies();
    }

    private void generateCookies()
    {
        while (currentCookies < maximumCookies)
        {
            if (currentCookies > spawnPoints.Count) break;
            int index = Random.Range(0, spawnPoints.Count);
            Vector3 point = spawnPoints[index];
            spawnPoints.Remove(point);
            GameObject spawn = (GameObject) Instantiate(cookiePrefab, point, Quaternion.identity);
            currentCookieMap.Add(point, spawn);
            currentCookies++;
        }
    }

    private void removeDeletedCookies()
    {
        foreach(KeyValuePair < Vector3, GameObject > entry in currentCookieMap)
        {
           if (entry.Value == null)
           {
                currentCookieMap.Remove(entry.Key);
                currentCookies--;
           }
        }
    }
}
