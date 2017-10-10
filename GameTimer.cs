using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

    public float levelSecs = 180;

    private Slider slider;
    private AudioSource audio;
    private float secondsLeft;
    private bool isLevelOver;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audio = GetComponent<AudioSource>();
        winLabel = GameObject.Find("You Win Label");
        winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        slider.value = Time.timeSinceLevelLoad / levelSecs;
        
        if (Time.timeSinceLevelLoad >= levelSecs && !isLevelOver)
        {
            print("Level won!");
            audio.Play();
            Invoke("LoadNextLevel", audio.clip.length);
            isLevelOver = true;
            winLabel.SetActive(true);
        }
	}

     void LoadNextLevel()
    {
        //Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
