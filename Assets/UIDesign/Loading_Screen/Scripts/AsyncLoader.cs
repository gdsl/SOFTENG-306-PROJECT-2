using UnityEngine;
using System.Collections;

public class AsyncLoader : MonoBehaviour {


    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.

    private AsyncOperation async = null; // When assigned, load is in progress.

    // Use this for initialization
    void Start () {
        Application.LoadLevel(3);
    }
	
	// Update is called once per frame
	void Update () {    }

    /*

    private void SyncLoadLevel(int level)
    {
        async = Application.LoadLevelAsync(level);
        Load();
    }

    IEnumerator Load()
    {
        yield return async;
    }

    void OnGUI()
    {
        if (async != null)
        {
            GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);
            GUI.DrawTexture(new Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(0, 0, 100, 50), string.Format("{0:N0}%", async.progress * 100f));
        }
    }
    */

}
