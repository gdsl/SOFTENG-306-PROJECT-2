using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyPanelScript : MonoBehaviour {

	public Sprite redKey;
	public Sprite yellowKey;
	public Image image1;
	public Image image2;
	public Image image3;

//	public Sprite yellowKey;
//	public Sprite greenKey;
//	public Sprite blueKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateKey(int id) {
		//Debug.LogError ("key found: " + id);

		if (id == 1) {
			image1.color = Color.white;
			image1.sprite = redKey;
		} else if (id == 2) {
			image2.color = Color.white;
			image2.sprite = yellowKey;
		}
	}
}
