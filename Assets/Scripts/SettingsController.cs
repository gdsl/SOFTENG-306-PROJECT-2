using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Slider musicVolumeSlider;
	public Slider soundEffectsVolumeSlider;
	public Slider brightnessSlider;
	public InputField nameInput;
    public GameObject confirmationPanel;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("musicVolume") || !PlayerPrefs.HasKey("soundEffectsVolume")
			|| !PlayerPrefs.HasKey("brightness")) {
			resetData();
		}
		musicVolumeSlider.value = PlayerPrefs.GetInt("musicVolume");
		soundEffectsVolumeSlider.value = PlayerPrefs.GetInt("soundEffectsVolume");
		brightnessSlider.value = (float)(PlayerPrefs.GetInt("brightness") / 100.00);
		nameInput.text = PlayerPrefs.GetString ("Name");
        confirmationPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MusicVolumeChanged() {
		PlayerPrefs.SetInt ("musicVolume", (int)musicVolumeSlider.value);
	}

	public void SoundEffectsVolumeChanged() {
		PlayerPrefs.SetInt ("soundEffectsVolume", (int)soundEffectsVolumeSlider.value);
	}

	public void BrightnessChanged() {
		PlayerPrefs.SetInt ("brightness", (int)(100*brightnessSlider.value));
	}

	public void NameTextChanged() {
		PlayerPrefs.SetString ("Name", nameInput.text);
	}

    public void resetData()
    {
        string name = PlayerPrefs.GetString("Name");
        PlayerPrefs.DeleteAll();
        musicVolumeSlider.value = musicVolumeSlider.maxValue/2;
        soundEffectsVolumeSlider.value = soundEffectsVolumeSlider.maxValue / 2;
		brightnessSlider.value = brightnessSlider.maxValue / 2;
        PlayerPrefs.SetString("Name", name);
    }

    public void showConfirmation()
    {
        confirmationPanel.SetActive(true);
    }

    public void hideConfirmation()
    {
        confirmationPanel.SetActive(false);
    }
}
