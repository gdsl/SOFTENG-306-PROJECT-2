using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AchievementController : MonoBehaviour {

    private List<bool> achievement;
    private GameObject[] lockedImage;
    private GameObject[] unlockedImage;
    
    //constant for different achievements
    public const int FIRST_LEVEL_COMPLETE = 0;
    public const int TEN_COOKIES = 1;
    public const int STAY_BELOW = 2;
    // Use this for initialization
	void Start () {
        //display where the achievement data is save on your computer
        print("saved file directory: " + Application.persistentDataPath);

        //find all achievement images and store them to use later on
        lockedImage = GameObject.FindGameObjectsWithTag("LockedAchievement");
        unlockedImage = GameObject.FindGameObjectsWithTag("UnlockedAchievement");
        
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
                int value = int.Parse(nameArray[0]) -1;
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
        else {
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
        }
	}
	

    public void setAchievement(int type)
    {
        print("called achievement");
        achievement.RemoveAt(type);
        achievement.Insert(type, true);


        //find the locked image for the targeted achievement and disable it
        foreach (GameObject image in lockedImage)
        {
            print(image.name);
            int count = type + 1;
            string name = count + " Locked";
            
            if (image.name.Equals(name))
            {
                image.SetActive(false);
                break;
            }
        }

        //find the unlocked image for the targeted achievement and enable it
        foreach (GameObject image in unlockedImage) {
            int count = type + 1;
            string name = count + " Unlocked";
            if (image.name.Equals(name))
            {
                image.SetActive(true);
                break;
            }
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/achievement.gd");
        bf.Serialize(file, achievement);
        file.Close();

    }
	// Update is called once per frame
	void Update () {
	
	}
}
