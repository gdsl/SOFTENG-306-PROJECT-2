using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Demo GUI skin components
/// </summary>
public class DemoGuiSkinMobile : MonoBehaviour {
	
	public List<Color> primaryColors;
	public List<Color> secondaryColors;

	private bool hasUpdatedGui = false;
	private int currentColor;
	
	private bool toggleValue;
	private float sliderValue;
	private string textValue ="Text field";
	
	private Rect dragWindowRect =  new Rect(100,50,300,300);
	
	/// <summary>
	/// Unity GUI hook.
	/// </summary>
	void OnGUI() {
		if (!hasUpdatedGui) {
			ColoredGUISkinMobile.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
			hasUpdatedGui = true;
		}
		GUI.skin = ColoredGUISkinMobile.Skin;
		
		// Window 
		dragWindowRect = GUI.Window (0, dragWindowRect, DoDragWindow, "Drag Window");

		// Alt Window 
		GUI.Window (1, new Rect(600,100,300,200), DoWindow, "Static Window");

		// Level Window 
		GUI.Window (2, new Rect(350,400,200,208), DoLevelWindow, "1      A Level", ColoredGUISkinMobile.Skin.customStyles[0]);
		
		// Level Window 
		GUI.Window (3, new Rect(500,400,200,208), DoLevelWindow, "2      A Level", ColoredGUISkinMobile.Skin.customStyles[0]);
		
		
		// Lock Window 
		GUI.Window (4, new Rect(650,400,200,208), DoLevelWindow, "", ColoredGUISkinMobile.Skin.customStyles[1]);
		
		// Switch Scene Button
		if (GUI.Button (new Rect (760,30,120,48), "To NGUI")) {
			Application.LoadLevel(0);	
		}
		
	}
	
	void DoDragWindow (int windowID) {
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		// Button
    	if (GUILayout.Button("Button")) {
       		Debug.Log("Clicked the button with text");
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		// Button
    	if (GUILayout.Button("Color")) {
       		currentColor++;
			ColoredGUISkinMobile.Instance.UpdateGuiColors(primaryColors[currentColor % primaryColors.Count],secondaryColors[currentColor % secondaryColors.Count]);
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
		// Text
		textValue = GUILayout.TextField(textValue, 50);
		
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		
		GUI.DragWindow();
	}
	
	void DoLevelWindow (int windowID) {
		if (windowID == 2) {
			GUILayout.Space(64);
			GUILayout.BeginHorizontal();
			GUILayout.Box ( "", ColoredGUISkinMobile.Skin.customStyles[2]);
			GUILayout.Box ( "", ColoredGUISkinMobile.Skin.customStyles[2]);
			GUILayout.EndHorizontal();
		}
	}
	
	void DoWindow (int windowID) {

		GUILayout.Space(64);
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		toggleValue = GUILayout.Toggle(toggleValue,"Toggle");
			
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		
	
	}
	
}
