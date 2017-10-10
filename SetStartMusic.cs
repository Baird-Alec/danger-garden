using UnityEngine;
using System.Collections;

public class SetStartMusic : MonoBehaviour {
    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        float volume = PlayerPrefsManager.GetMasterVolume();
        musicManager.ChangeVolume(volume);
	}
}
