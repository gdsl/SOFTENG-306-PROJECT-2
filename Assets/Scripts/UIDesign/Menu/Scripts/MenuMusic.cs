using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	public AudioSource audioSource;
    private static MenuMusic instance = null;
    public static MenuMusic Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

	void Start() 
	{
		PlayerPrefs.SetInt("musicVolume", 500);
		PlayerPrefs.SetInt ("soundEffectsVolume", 500);
	}

	void Update()
	{
		audioSource.volume = (float)PlayerPrefs.GetInt("musicVolume")/100;
	}
}
