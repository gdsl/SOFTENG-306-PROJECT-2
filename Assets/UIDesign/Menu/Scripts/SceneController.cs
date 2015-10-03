using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public GameObject achievementScreen;
	// Use this for initialization
	void Start () {
        achievementScreen = GameObject.FindGameObjectWithTag("AchievementScreen");
        achievementScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	   
	}

    public void moveScene(int scene)
    { 
            Application.LoadLevel(scene);
    }

    public void showAchievement()
    {
        achievementScreen.SetActive(true);
    }

    public void hideAchievement()
    {
        achievementScreen.SetActive(false);
    }



}
