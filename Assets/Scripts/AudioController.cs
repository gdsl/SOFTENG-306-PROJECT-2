using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private AudioSource highSuspicionAudio;
	private AudioSource keyAudio;
	private AudioSource cookieAudio;
	private AudioSource unlockDoorAudio;
	private AudioSource winGameAudio;
	private AudioSource creakyFloorAudio;

	// Use this for initialization
	void Start () {
		highSuspicionAudio = GameObject.FindGameObjectWithTag("HighSuspicionAudio").GetComponent<AudioSource>();
		keyAudio = GameObject.FindGameObjectWithTag("KeyAudio").GetComponent<AudioSource>();
		cookieAudio = GameObject.FindGameObjectWithTag("EatCookieAudio").GetComponent<AudioSource>();
		unlockDoorAudio = GameObject.FindGameObjectWithTag("UnlockDoorAudio").GetComponent<AudioSource>();
		winGameAudio = GameObject.FindGameObjectWithTag("WinGameAudio").GetComponent<AudioSource>();
		creakyFloorAudio = GameObject.FindGameObjectWithTag("CreakyAudio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//high suspicion is music?
		highSuspicionAudio.volume = (float)PlayerPrefs.GetInt("musicVolume")/1000;

		keyAudio.volume = (float)PlayerPrefs.GetInt("soundEffectsVolume")/1000;
		cookieAudio.volume = (float)PlayerPrefs.GetInt("soundEffectsVolume")/1000;
		unlockDoorAudio.volume = (float)PlayerPrefs.GetInt("soundEffectsVolume")/1000;
		winGameAudio.volume = (float)PlayerPrefs.GetInt("soundEffectsVolume")/1000;
		creakyFloorAudio.volume = (float)PlayerPrefs.GetInt("soundEffectsVolume")/1000;
	}
}
