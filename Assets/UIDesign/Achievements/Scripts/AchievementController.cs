using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AchievementController : MonoBehaviour {

    private List<bool> achievement;
    //public enum AchievementType { FIRST_LEVEL_COMPLETE, TEN_COOKIES, STAY_BELOW }
    public const int FIRST_LEVEL_COMPLETE = 0;
    public const int TEN_COOKIES = 1;
    public const int STAY_BELOW = 2;
    // Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/achievement.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/achievement.gd", FileMode.Open);
            achievement = (List<bool>)bf.Deserialize(file);
            file.Close();

            GameObject[] lockedImage = GameObject.FindGameObjectsWithTag("LockedAchievement");
            GameObject[] unlockedImage = GameObject.FindGameObjectsWithTag("UnlockedAchievement");
            
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
                image.SetActive(!achievement[value]);
            }
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
        }
	}
	

    public void unlockAchievement(int type)
    {
        achievement.RemoveAt(type);
        achievement.Insert(type, true);

        GameObject[] lockedImage = GameObject.FindGameObjectsWithTag("LockedAchievement");
        GameObject[] unlockedImage = GameObject.FindGameObjectsWithTag("UnlockedAchievement");

        foreach (GameObject image in lockedImage)
        {
            int count = type + 1;
            string name = count + " Locked";
            
            if (image.name.Equals(name))
            {
                image.SetActive(false);
                break;
            }
        }

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
