using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LevelEnd : MonoBehaviour {

    private GameObject player;
	public GameObject successScreen;
	public Text successText;
	public Text cookieText;
	public Text timeText;
	public Slider suspicionSlider;

	private int stars;
	private int score;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            //play success audio
            AudioSource winAudio = GameObject.FindGameObjectWithTag("WinGameAudio").GetComponent<AudioSource>();
            winAudio.Play();
            Debug.Log("Delivered present to tree");



            //Application.LoadLevel("EndLevel");
			CalculateScore();

            if (!successText.text.Contains("Score:"))
                successText.text += "Score: " + score;

			successScreen.SetActive(true);


            GameObject achievementController = GameObject.FindGameObjectWithTag("AchievementController");
            AchievementController controller = achievementController.GetComponent<AchievementController>();
            if (suspicionSlider.value <= suspicionSlider.maxValue/2 && Application.loadedLevel == 4)
            {
                controller.setAchievement(AchievementController.STAY_BELOW);
            }

            float time = 0;
            float.TryParse(timeText.text.Split(' ')[1], out time);
            if (Application.loadedLevel == 4) controller.setAchievement(AchievementController.FIRST_LEVEL_COMPLETE);

			GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
			GameController gameControllerScript = gameController.GetComponent<GameController>();
			gameControllerScript.StopGame();

            int cookies = 0;
            int.TryParse(cookieText.text.Split(' ')[1], out cookies);
            int currentCookie = PlayerPrefs.GetInt(AchievementController.COOKIE_COUNT);
            int totalCookies = currentCookie + cookies;
            if (totalCookies >= 10) controller.setAchievement(AchievementController.TEN_COOKIES);
            PlayerPrefs.SetInt(AchievementController.COOKIE_COUNT, totalCookies);

            if (Application.loadedLevel == 5 && time <= 120) controller.setAchievement(AchievementController.SPEED_RUNNER);
            if (Application.loadedLevel == 5 && cookies == 4) controller.setAchievement(AchievementController.EXPLORER);

            updateLevelInfo();
        }
    }

	public void CalculateScore() {
		int cookies = 0;
		int.TryParse(cookieText.text.Split(' ')[1], out cookies);
		float time = 0;
		float.TryParse(timeText.text.Split(' ')[1], out time);
		score = (int) (6000 - 0.25*suspicionSlider.value + cookies * 500 - 30*time);

		if (score < 300) {
			System.Random rnd = new System.Random();
			score = rnd.Next(100,500); //make the player feel a bit better
		}

		if (score > 3000) {
			stars = 3;
		} else if (score > 2000) {
			stars = 2;
		} else {
			stars = 1; 
		}
	}

    public int getStar()
    {
        return stars;
    }

    public int getScore()
    {
        return score;
    }

    public void updateLevelInfo()
    {
        if (PlayerPrefs.GetInt("To Be Loaded") == 4)
        {
            if (stars > PlayerPrefs.GetInt("Level One Stars"))
            {
                PlayerPrefs.SetInt("Level One Stars", stars);
            }

            if (score > PlayerPrefs.GetInt("Level One Score"))
            {
                PlayerPrefs.SetInt("Level One Score", score);
            }
        }
        else if (PlayerPrefs.GetInt("To Be Loaded") == 5)
        {
            if (stars > PlayerPrefs.GetInt("Level Two Stars"))
            {
                PlayerPrefs.SetInt("Level Two Stars", stars);
            }

            if (score > PlayerPrefs.GetInt("Level Two Score"))
            {
                PlayerPrefs.SetInt("Level Two Score", score);
            }
        }

        GameObject scoreUploadController = GameObject.FindGameObjectWithTag("ScoreUploadController");
        ScoreUploadController controller = scoreUploadController.GetComponent<ScoreUploadController>();
        controller.setScore(score);
    }
}
