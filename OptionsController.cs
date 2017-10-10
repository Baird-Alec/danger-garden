using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
    public  Slider volumeSlider;
    public  Slider difficultySlider;
    public LevelManager level;
    private MusicManager music;
	// Use this for initialization
	void Start () {
        music = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetLevelDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        music.ChangeVolume(volumeSlider.value);
	}
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetLevelDifficulty(difficultySlider.value);
        level.LoadLevel("Start");
    }
    public void SetDefaults()
    {
        volumeSlider.value = .5f;
        difficultySlider.value = 2;
    }
}
