using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameController : MonoBehaviour {

    public GameObject img;
    public Text text;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("Name") || !PlayerPrefs.HasKey("musicVolume") || !PlayerPrefs.HasKey("soundEffectsVolume")
		    || !PlayerPrefs.HasKey("brightness") || !PlayerPrefs.HasKey("snow")) {

			PlayerPrefs.SetInt ("musicVolume", 1000);
			PlayerPrefs.SetInt ("soundEffectsVolume", 1000);
			PlayerPrefs.SetInt ("brightness", 100);
			PlayerPrefs.SetInt ("snow", 1);
			PlayerPrefs.SetInt ("vibrate", 1);
			img.SetActive(true);
		}
//	    if (PlayerPrefs.GetString("Name").Length > 0)
//        {
//            img.SetActive(false);
//            Debug.Log(PlayerPrefs.GetString("Name"));
//        }
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
