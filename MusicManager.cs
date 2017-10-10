using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChange;
    private AudioSource source;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnLevelWasLoaded(int level)
    {
        AudioClip musicLevel = levelMusicChange[level];
        if(musicLevel)
        {
            source.clip = musicLevel;
            source.loop = true;
            source.Play();
        }
    }
    public void ChangeVolume(float value)
    {
        source.volume = value;
    }
}
