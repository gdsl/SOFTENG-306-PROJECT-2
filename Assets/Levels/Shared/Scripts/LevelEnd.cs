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
            Debug.Log("Delivered present to tree");
            //Application.LoadLevel("EndLevel");
			CalculateScore();
			successText.text += " - Score: " + score;
			successScreen.SetActive(true);

        }
    }

	void CalculateScore() {
		int cookies = int.Parse(cookieText.text.Split(' ')[1]);
		float time = float.Parse(timeText.text.Split(' ')[1]);
		score = (int) (5000 - suspicionSlider.value + cookies * 500 + time);

		if (score > 3000) {
			stars = 3;
		} else if (score > 2000) {
			stars = 2;
		} else {
			stars = 1; 
		}
	}
}
