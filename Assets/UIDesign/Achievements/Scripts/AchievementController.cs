using UnityEngine;
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
    public const string FIRST_LEVEL_COMPLETE = "FIRST_LEVEL_COMPLETE";
    public const string TEN_COOKIES = "TEN_COOKIES";
    public const string STAY_BELOW = "STAY_BELOW";
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
        achievement.Add(TEN_COOKIES);
        achievement.Add(STAY_BELOW);

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

                if (PlayerPrefs.GetInt(achievement[value]) == locked) {
                    image.SetActive(true);
                } else
                {
                    image.SetActive(false);
                }

                

            }

            foreach (GameObject image in unlockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value
                string[] nameArray = image.name.Split(' ');
                int value = int.Parse(nameArray[0]) - 1;
                if (PlayerPrefs.GetInt(achievement[value]) == unlocked)
                {
                   image.SetActive(true);
                }
                else
                {
                    image.SetActive(false);
                }

            }

        } else
        {
            PlayerPrefs.SetInt(FIRST_LEVEL_COMPLETE, locked);
            PlayerPrefs.SetInt(TEN_COOKIES, locked);
            PlayerPrefs.SetInt(STAY_BELOW, locked);
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

        
        /*
        //create new achievement game data if not open existing one
        if (File.Exists(Application.persistentDataPath + "/achievement.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/achievement.gd", FileMode.Open);
            achievement = (List<bool>)bf.Deserialize(file);

            //change the UI corresponding to the existing achievement data
            foreach (GameObject image in lockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value

                string[] nameArray = image.name.Split(' ');
                int value = int.Parse(nameArray[0]) - 1;
                image.SetActive(!achievement[value]);

            }

            foreach (GameObject image in unlockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value
                string[] nameArray = image.name.Split(' ');
                int value = int.Parse(nameArray[0]) - 1;
                image.SetActive(achievement[value]);

            }
            file.Close();
        }
        else
        {
            achievement = new List<bool>();
            achievement.Add(false);
            achievement.Add(false);
            achievement.Add(false);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/achievement.gd");
            bf.Serialize(file, achievement);
            file.Close();

            foreach (GameObject image in lockedImage)
            {
                //game object are named in "1 Locked", "2 Locked". split the string to get the value
                image.SetActive(true);

            }

            foreach (GameObject image in unlockedImage)
            {
                image.SetActive(false);
            }
        } */
    }

    public void setAchievement(string type)
    {
        print("called achievement");
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
