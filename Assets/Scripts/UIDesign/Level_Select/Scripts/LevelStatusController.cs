using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelStatusController : MonoBehaviour {

    public Image[] levelOneStars;
    public RawImage lockOne;

    public Image[] levelTwoStars;
    public RawImage lockTwo;

    public Image[] levelThreeStars;
    public RawImage lockThree;

    public Text levelOneHighScore;
    public Text levelTwoHighScore;
    public Text levelThreeHighScore;

    private Color starCompleteColor = Color.yellow;
    private Color starEmptyColor = Color.white;

    // Use this for initialization
    void Start () {
        //to be refractored later

        doSetup();

    }

    private void doSetup()
    {
        setPageLevelOne();
        setPageLevelTwo();
        setPageLevelThree();
    }

    private void setPageLevelOne() {
        int levelOneStarsInt = PlayerPrefs.GetInt("Level One Stars");

        levelTwoStars[0].enabled = false;
        levelTwoStars[1].enabled = false;
        levelTwoStars[2].enabled = false;

        if (levelOneStarsInt > 0)
        {
            levelOneStars[0].color = starCompleteColor;
            if (levelOneStarsInt > 1)
            {
                levelOneStars[1].color = starCompleteColor;
                if (levelOneStarsInt > 2)
                {
                    levelOneStars[2].color = starCompleteColor;
                }
            }
        }

        levelOneHighScore.text = PlayerPrefs.GetInt("Level One Score") + "";

    }


    private void setPageLevelTwo() {
        

        int levelTwoStarsInt = PlayerPrefs.GetInt("Level Two Stars");

        if (levelTwoStarsInt > 0)
        {
            levelTwoStars[0].color = starCompleteColor;
            if (levelTwoStarsInt > 1)
            {
                levelOneStars[1].color = starCompleteColor;
                if (levelTwoStarsInt > 2)
                {
                    levelTwoStars[2].color = starCompleteColor;
                }
            }
        }

        levelTwoHighScore.text = PlayerPrefs.GetInt("Level Two Score") + "";

    }


    private void setPageLevelThree() {


        levelThreeHighScore.text = PlayerPrefs.GetInt("Level Three Score") + "";
    }
    // Update is called once per frame
    void Update () {
	
	}
}
