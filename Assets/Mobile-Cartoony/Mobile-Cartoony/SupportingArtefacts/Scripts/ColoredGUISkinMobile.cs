using UnityEngine;
using System.Collections;

public class ColoredGUISkinMobile : MonoBehaviour {
	
	/// <summary>
	/// The custom skin to demo.
	/// </summary>
	public GUISkin customSkin;
	
	/// <summary>
	/// The scaling factor use if we need to change the size of the UI.
	/// </summary>
	public float scalingFactor = 2.0f;
	
	/// <summary>
	/// Sets the skin.
	/// </summary>
	/// <value>
	/// The skin.
	/// </value>
	public static GUISkin Skin {
		get {if (Instance != null) return Instance.actualSkin; return null;}
	}
	
	public static ColoredGUISkinMobile Instance{
		get; private set;
	}	
	
	private GUISkin actualSkin;
	
	void Awake(){
		Instance = this;	
	}
	
	public void UpdateGuiColors(Color color, Color secondaryColor) {
		GUI.skin = customSkin;
		actualSkin = (GUISkin) ScriptableObject.CreateInstance(typeof(GUISkin));
		
		// Button
		actualSkin.button = new GUIStyle("button");
		actualSkin.button.normal.background = UpdateGuiSkin(customSkin.button.normal.background, color);
		actualSkin.button.hover.background = UpdateGuiSkin(customSkin.button.hover.background, color);
		actualSkin.button.active.background = UpdateGuiSkin(customSkin.button.active.background, color);
		actualSkin.button.normal.textColor = secondaryColor;
		actualSkin.button.hover.textColor = secondaryColor;
		actualSkin.button.active.textColor = secondaryColor;
		
		// Window
		actualSkin.window = new GUIStyle("window");
		actualSkin.window.normal.background = UpdateGuiSkin(customSkin.window.normal.background, color);
		actualSkin.window.hover.background = UpdateGuiSkin(customSkin.window.hover.background, color);
		actualSkin.window.onNormal.background = UpdateGuiSkin(customSkin.window.onNormal.background, color);
		actualSkin.window.normal.textColor = secondaryColor;
		actualSkin.window.onNormal.textColor = secondaryColor;
		actualSkin.window.hover.textColor = secondaryColor;
		actualSkin.window.active.textColor = secondaryColor;
		actualSkin.window.focused.textColor = secondaryColor;

		
		// TextArea
		actualSkin.textField = new GUIStyle("textfield");
		actualSkin.textField.normal.background = UpdateGuiSkin(customSkin.textField.normal.background, color);
		actualSkin.textField.hover.background = UpdateGuiSkin(customSkin.textField.hover.background, color);
		actualSkin.textField.focused.background = UpdateGuiSkin(customSkin.textField.focused.background, color);
		actualSkin.textField.active.background = UpdateGuiSkin(customSkin.textField.active.background, color);
		actualSkin.textField.onNormal.background = UpdateGuiSkin(customSkin.textField.onNormal.background, color);
		
		// Box
		actualSkin.box = new GUIStyle("box");
		actualSkin.box.normal.background = UpdateGuiSkin(customSkin.box.normal.background, color);
		actualSkin.box.normal.textColor = secondaryColor;
		actualSkin.box.onNormal.textColor = secondaryColor;
		actualSkin.box.hover.textColor = secondaryColor;
		actualSkin.box.active.textColor = secondaryColor;
		actualSkin.box.focused.textColor = secondaryColor;
		
		// Toggle
		actualSkin.toggle = new GUIStyle("toggle");
		actualSkin.toggle.normal.background = UpdateGuiSkin(customSkin.toggle.normal.background, color);
		actualSkin.toggle.hover.background = UpdateGuiSkin(customSkin.toggle.hover.background, color);
		actualSkin.toggle.active.background = UpdateGuiSkin(customSkin.toggle.active.background, color);
		
		actualSkin.toggle.onNormal.background = UpdateGuiSkin(customSkin.toggle.onNormal.background, color);
		actualSkin.toggle.onHover.background = UpdateGuiSkin(customSkin.toggle.onHover.background, color);
		actualSkin.toggle.onActive.background = UpdateGuiSkin(customSkin.toggle.onActive.background, color);
		
		// Label
		actualSkin.label = new GUIStyle("label");
		actualSkin.label.normal.textColor = color;
		
		// Scroll bar
		actualSkin.verticalScrollbar = new GUIStyle("verticalscrollbar");
		actualSkin.verticalScrollbar.normal.background = UpdateGuiSkin(customSkin.verticalScrollbar.normal.background, color);
		
		// Scroll bar thumb
		actualSkin.verticalScrollbarThumb = new GUIStyle("verticalscrollbarthumb");
		actualSkin.verticalScrollbarThumb.normal.background = UpdateGuiSkin(customSkin.verticalScrollbarThumb.normal.background, secondaryColor);
		
		// Custom
		actualSkin.customStyles = new GUIStyle[3];
		
		// Alternate Window
		actualSkin.customStyles[0] = new GUIStyle("level-window");
		actualSkin.customStyles[0].normal.background = UpdateGuiSkin(customSkin.FindStyle ("level-window").normal.background, color);
		actualSkin.customStyles[0].normal.textColor = secondaryColor;
		actualSkin.customStyles[0].onNormal.textColor = secondaryColor;
		actualSkin.customStyles[0].hover.textColor = secondaryColor;
		actualSkin.customStyles[0].active.textColor = secondaryColor;
		actualSkin.customStyles[0].focused.textColor = secondaryColor;
		
		actualSkin.customStyles[1] = new GUIStyle("level-locked-window");
		actualSkin.customStyles[1].normal.background = UpdateGuiSkin(customSkin.FindStyle ("level-locked-window").normal.background, color);
		actualSkin.customStyles[1].normal.textColor = secondaryColor;
		actualSkin.customStyles[1].onNormal.textColor = secondaryColor;
		actualSkin.customStyles[1].hover.textColor = secondaryColor;
		actualSkin.customStyles[1].active.textColor = secondaryColor;
		actualSkin.customStyles[1].focused.textColor = secondaryColor;
			
		actualSkin.customStyles[2] = new GUIStyle("star");
		actualSkin.customStyles[2].normal.background = UpdateGuiSkin(customSkin.FindStyle ("star").normal.background, secondaryColor);
	}
	
	private Texture2D UpdateGuiSkin(Texture2D texture, Color primaryColor) {
		Texture2D newTexture = new Texture2D((int)(texture.width / scalingFactor), (int) (texture.height / scalingFactor), texture.format, false);
		for (int i = 0; i < newTexture.width; i++) {
			for (int j = 0; j < newTexture.height; j++) {
				Color color = texture.GetPixelBilinear(((float)i * scalingFactor) / texture.width, ((float)j * scalingFactor) / texture.height) * primaryColor;
				newTexture.SetPixel(i, j, color);
			}
		}
		newTexture.Apply();
		return newTexture;
	}
	
	
}
