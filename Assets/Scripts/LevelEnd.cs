using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
			successText.text += "Score: " + score;
			successScreen.SetActive(true);


            GameObject achievementController = GameObject.FindGameObjectWithTag("AchievementController");
            AchievementController controller = achievementController.GetComponent<AchievementController>();
            controller.setAchievement(AchievementController.FIRST_LEVEL_COMPLETE);

            if (stars > PlayerPrefs.GetInt("Level One Stars"))
            {
                PlayerPrefs.SetInt("Level One Stars", stars);
            }
        }
    }

	void CalculateScore() {
		int cookies = 0;
		int.TryParse(cookieText.text.Split(' ')[1], out cookies);
		float time = 0;
		float.TryParse(timeText.text.Split(' ')[1], out time);
		score = (int) (5000 - suspicionSlider.value + cookies * 500 - time);

		if (score > 3000) {
			stars = 3;
		} else if (score > 2000) {
			stars = 2;
		} else {
			stars = 1; 
		}
	}
}
