using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public Image levelOneStarOne;
    public Image levelOneStarTwo;
    public Image levelOneStarThree;
    public Image levelOneLock;

    public Image levelTwoStarOne;
    public Image levelTwoStarTwo;
    public Image levelTwoStarThree;
    public Image levelTwoLock;

    public Color starColor;

	// Use this for initialization
	void Start () {
        starColor = Color.yellow;
        int levelOneStars = PlayerPrefs.GetInt("Level One Stars");

        if(levelOneStars > 0)
        {
            levelOneStarOne.color = starColor;
            if(levelOneStars > 1)
            {
                levelOneStarTwo.color = starColor;
                if(levelOneStars > 2)
                {
                    levelOneStarThree.color = starColor;
                }
            }

            levelTwoLock.enabled = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    public void moveScene(int scene)
    { 
            Application.LoadLevel(scene);
    }
}
