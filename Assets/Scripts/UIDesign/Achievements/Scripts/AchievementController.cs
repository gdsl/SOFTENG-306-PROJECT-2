using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AchievementController : MonoBehaviour {

    //private List<bool> achievement;
    private List<string> achievement = new List<string>();
    private GameObject[] lockedImage;
    private GameObject[] unlockedImage;

    //constant for different achievements
    public const string COOKIE_COUNT = "COOKIE_COUNT";
    public const string FIRST_LEVEL_COMPLETE = "FIRST_LEVEL_COMPLETE";
    public const string TEN_COOKIES = "TEN_COOKIES";
    public const string STAY_BELOW = "STAY_BELOW";
    public const string SPEED_RUNNER = "SPEED_RUNNER";
    public const string EXPLORER = "EXPLORER";
    public const string MULTIPLAYER_WIN = "MULTIPLAYER_WIN";
	public const string PLACE_HOLDER = "PLACE_HOLDER";
    public const int locked = 1;
    public const int unlocked = 2;
    // Use this for initialization
    void Start () {
        //display where the achievement data is save on your computer
        //print("saved file directory: " + Application.persistentDataPath);
        
        

        Setup();
	}
	
    public void Setup()
    {
        achievement.Add(FIRST_LEVEL_COMPLETE);
        achievement.Add(STAY_BELOW);
        achievement.Add(TEN_COOKIES);
		achievement.Add (SPEED_RUNNER);
		achievement.Add (EXPLORER);
		achievement.Add (MULTIPLAYER_WIN);

        //find all achievement images and store them to use later on
        lockedImage = GameObject.FindGameObjectsWithTag("LockedAchievement");
        unlockedImage = GameObject.FindGameObjectsWithTag("UnlockedAchievement");

        if (PlayerPrefs.HasKey(FIRST_LEVEL_COMPLETE))
        {
            //change the UI corresponding to the existing achievement data
            foreach (GameObject image in lockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value

                string[] nameArray = image.name.Split(' ');
                int value = int.Parse(nameArray[0]) - 1;

				int result = PlayerPrefs.GetInt(achievement[value]);
                if (result == locked) {
                    image.SetActive(true);
				} else if (result == unlocked) {
					image.SetActive(false);
				} else if (result == 0) {
					PlayerPrefs.SetInt(achievement[value],locked);
					image.SetActive(true);
                } 

                

            }

            foreach (GameObject image in unlockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value
                string[] nameArray = image.name.Split(' ');
                int value = int.Parse(nameArray[0]) - 1;
				Image iconHolder = image.transform.parent.transform.Find ("IconHolder").GetComponent<Image>();
				int result = PlayerPrefs.GetInt(achievement[value]);
				if (result == unlocked) {
					image.SetActive(true);
					iconHolder.color = new Color(255,0,0);
				} else if (result == locked) {
					image.SetActive(false);
					iconHolder.color = new Color(255,255,255);
				} else if (result == 0) {
					PlayerPrefs.SetInt(achievement[value],locked);
					iconHolder.color = new Color(255,255,255);
					image.SetActive(false);
				}

            }

        } else
        {
            PlayerPrefs.SetInt(FIRST_LEVEL_COMPLETE, locked);
            PlayerPrefs.SetInt(TEN_COOKIES, locked);
            PlayerPrefs.SetInt(STAY_BELOW, locked);
			PlayerPrefs.SetInt(PLACE_HOLDER, locked);
            PlayerPrefs.SetInt(SPEED_RUNNER, locked);
            PlayerPrefs.SetInt(EXPLORER, locked);
            PlayerPrefs.SetInt(MULTIPLAYER_WIN, locked);
            PlayerPrefs.Save();

            foreach (GameObject image in lockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value
                image.SetActive(true);

            }

            foreach (GameObject image in unlockedImage)
            {
                image.SetActive(false);
            }
        }

    }

    public void setAchievement(string type)
    {
        PlayerPrefs.SetInt(type, unlocked);


        //find the locked image for the targeted achievement and disable it
        foreach (GameObject image in lockedImage)
        {
            print(image.name);
            int count = achievement.IndexOf(type);
            string name = count + " Locked";
            
            if (image.name.Equals(name))
            {
                image.SetActive(false);
                break;
            }
        }

        //find the unlocked image for the targeted achievement and enable it
        foreach (GameObject image in unlockedImage) {
            int count = achievement.IndexOf(type);
            string name = count + " Unlocked";
            if (image.name.Equals(name))
            {
                image.SetActive(true);
                break;
            }
        }

        PlayerPrefs.Save();

    }
	// Update is called once per frame
	void Update () {
	
	}
}
