using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour {
    
    public Image progressBar;
    public Text text;

    private int loadProgress = 0;
 
     // Use this for initialization
     void Start()
    {
        StartCoroutine(DisplayLoadingScreen(3));
    }
     
     // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DisplayLoadingScreen(int level)
    {
        progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y);

        text.GetComponent<Text>().text = "Loading Progress " + loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);

        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            text.GetComponent<Text>().text = "Loading Progress " + loadProgress + "%";
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y);
            yield return null;
        }
        
    }
}