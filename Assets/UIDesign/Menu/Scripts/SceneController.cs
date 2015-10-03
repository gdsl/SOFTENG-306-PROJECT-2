using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    public void moveScene(int scene)
    { 
            Application.LoadLevel(scene);
    }
}
