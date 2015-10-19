using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {

    [SerializeField]
    Texture2D padBackground;

    [SerializeField]
    Texture2D padController;

    bool isMovingFinger = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];

            Vector2 touchPosition = new Vector2(touch.position.x, Screen.height - touch.position.y);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Canceled:
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }
	
	}
}


//public void OnGUI()
//{
//    /** gui code **/
//}