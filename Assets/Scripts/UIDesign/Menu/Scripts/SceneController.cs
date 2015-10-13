using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    private GameObject achievementScreen;
	// Use this for initialization
	void Start () {

        Time.timeScale = 1.0F;

        GameObject achievementController = GameObject.FindGameObjectWithTag("AchievementController");

        achievementScreen = GameObject.FindGameObjectWithTag("AchievementScreen");
        if (achievementScreen != null)
        {
            if (achievementController != null)
            {
                AchievementController controller = achievementController.GetComponent<AchievementController>();
                controller.Setup();
            }

            achievementScreen.SetActive(false);
            RectTransform rt = achievementScreen.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.sizeDelta = new Vector2(1500, 600);
            rt.localPosition = new Vector3(0, 0, 0);
        }

        
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            GameObject achievementController = GameObject.FindGameObjectWithTag("AchievementController");
            if (achievementController != null)
            {
                AchievementController controller = achievementController.GetComponent<AchievementController>();
                controller.Setup();
            }
        }
    }

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}

    public void moveToGame(int gameLevel)
    {
        PlayerPrefs.SetInt("To Be Loaded", gameLevel);
        moveScene(3);
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
