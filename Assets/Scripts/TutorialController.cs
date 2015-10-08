using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public GameObject santa;
	public GameObject lockedDoor;
	public GameObject creakyFloorBoard;
	public GameObject sofa;
	public GameObject table;
	public GameObject firePlace;
	public Text hintText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 santaPos = santa.transform.position;
		Vector3 lockedDoorPos = lockedDoor.transform.position;
		Vector3 creakyFloorBoardPos = creakyFloorBoard.transform.position;
		Vector3 sofaPos = sofa.transform.position;
		Vector3 tablePos = table.transform.position;
		Vector3 fireplacePos = firePlace.transform.position;

		if (Distance (santaPos.x, santaPos.z, lockedDoorPos.x, lockedDoorPos.z) < 2) {
			ShowHint ("Find the correct key to open this door!");
		} else if (Distance (santaPos.x, santaPos.z, creakyFloorBoardPos.x, creakyFloorBoardPos.z) < 2) {
			ShowHint ("The creaky floor board will attract attention!");
		} else if (Distance (santaPos.x, santaPos.z, sofaPos.x, sofaPos.z) < 2) {
			ShowHint ("Don't get spotted!");
		} else if (Distance (santaPos.x, santaPos.z, tablePos.x, tablePos.z) < 2) {
			ShowHint ("Collect the cookie for extra score!");
		} else if (Distance (santaPos.x, santaPos.z, fireplacePos.x, fireplacePos.z) < 2) {
			ShowHint ("Find the christmas tree to deliver the present!");
		} else {
			HideHint();
		}
	}

	private void ShowHint(string s) {
		hintText.text = s;
		hintText.gameObject.SetActive (true);
	}

	private void HideHint() {
		hintText.gameObject.SetActive (false);
	}

	private float Distance(float x1, float y1, float x2, float y2) {
		return Mathf.Sqrt((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2));
	}

}
