using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameController : MonoBehaviour {

    public GameObject img;
    public Text text;

	// Use this for initialization
	void Start () {
	    if (PlayerPrefs.GetString("Name").Length > 0)
        {
            img.SetActive(false);
            Debug.Log(PlayerPrefs.GetString("Name"));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterName()
    {
        PlayerPrefs.SetString("Name", text.text);
        img.SetActive(false);
    }
}
