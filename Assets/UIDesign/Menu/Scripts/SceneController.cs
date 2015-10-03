using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    private GameObject achievementScreen;
	// Use this for initialization
	void Start () {
        achievementScreen = GameObject.FindGameObjectWithTag("AchievementScreen");
        if (achievementScreen != null) achievementScreen.SetActive(false);
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
