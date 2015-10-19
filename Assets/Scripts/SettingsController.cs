using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Slider musicVolumeSlider;
	public Slider soundEffectsVolumeSlider;
	public Slider brightnessSlider;
	public InputField nameInput;
    public GameObject confirmationPanel;
	public Toggle snowToggle;
	public Toggle vibrateToggle;

	// Use this for initialization
	void Start ()
    {
		if (!PlayerPrefs.HasKey("musicVolume") || !PlayerPrefs.HasKey("soundEffectsVolume")
			|| !PlayerPrefs.HasKey("brightness")) {
			ResetData();
		}
		musicVolumeSlider.value = PlayerPrefs.GetInt("musicVolume");
		soundEffectsVolumeSlider.value = PlayerPrefs.GetInt("soundEffectsVolume");
		brightnessSlider.value = (float)(PlayerPrefs.GetInt("brightness") / 100.00);
		nameInput.text = PlayerPrefs.GetString ("Name");
		if (PlayerPrefs.GetInt ("snow") == 1) {
			snowToggle.isOn = true;
		} else {
			snowToggle.isOn = false;
		}
		if (PlayerPrefs.GetInt ("vibrate") == 1) {
			vibrateToggle.isOn = true;
		} else {
			vibrateToggle.isOn = false;
		}
        confirmationPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MusicVolumeChanged() 
    {
		PlayerPrefs.SetInt ("musicVolume", (int)musicVolumeSlider.value);
	}

	public void SoundEffectsVolumeChanged()
    {
		PlayerPrefs.SetInt ("soundEffectsVolume", (int)soundEffectsVolumeSlider.value);
	}

	public void BrightnessChanged() 
    {
		PlayerPrefs.SetInt ("brightness", (int)(100*brightnessSlider.value));
	}

	public void NameTextChanged() 
    {
		PlayerPrefs.SetString ("Name", nameInput.text);
	}

    public void ResetData()
    {
        string name = PlayerPrefs.GetString("Name");
        PlayerPrefs.DeleteAll();
        musicVolumeSlider.value = musicVolumeSlider.maxValue;
        soundEffectsVolumeSlider.value = soundEffectsVolumeSlider.maxValue;
		brightnessSlider.value = brightnessSlider.maxValue;
		snowToggle.isOn = true;
		vibrateToggle.isOn = true;
        PlayerPrefs.SetString("Name", name);
    }

	public void SnowToggleChanged() {
		if (snowToggle.isOn) {
			PlayerPrefs.SetInt ("snow", 1);
		} else {
			PlayerPrefs.SetInt ("snow", 0);
		}
	}

	public void VibrateToggleChanged() {
		if (vibrateToggle.isOn) {
			PlayerPrefs.SetInt ("vibrate", 1);
		} else {
			PlayerPrefs.SetInt ("vibrate", 0);
		}
	}

    public void ShowConfirmation()
    {
        confirmationPanel.SetActive(true);
    }

    public void HideConfirmation()
    {
        confirmationPanel.SetActive(false);
    }
}
