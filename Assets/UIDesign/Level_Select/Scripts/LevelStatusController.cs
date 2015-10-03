using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelStatusController : MonoBehaviour {

    public Image levelOneStarOne;
    public Image levelOneStarTwo;
    public Image levelOneStarThree;
    public Image levelOneLock;

    public Image levelTwoStarOne;
    public Image levelTwoStarTwo;
    public Image levelTwoStarThree;
    public Image levelTwoLock;

    // Use this for initialization
    void Start () {
        //to be refractored later

        Color starCompleteColor = Color.yellow;
        Color starEmptyColor = Color.white;

        int levelOneStars = PlayerPrefs.GetInt("Level One Stars");

        levelTwoStarOne.enabled = false;
        levelTwoStarTwo.enabled = false;
        levelTwoStarThree.enabled = false;

        if (levelOneStars > 0)
        {
            levelOneStarOne.color = starCompleteColor;
            if (levelOneStars > 1)
            {
                levelOneStarTwo.color = starCompleteColor;
                if (levelOneStars > 2)
                {
                    levelOneStarThree.color = starCompleteColor;
                }
            }

            levelTwoLock.enabled = false;
            levelTwoStarOne.enabled = true;
            levelTwoStarTwo.enabled = true;
            levelTwoStarThree.enabled = true;
            levelTwoStarOne.color = starEmptyColor;
            levelTwoStarTwo.color = starEmptyColor;
            levelTwoStarThree.color = starEmptyColor;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
