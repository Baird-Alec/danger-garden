using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master volume";
    const string LEVEL_DIFFICULTY = "level difficulty";
    const string LEVEL_UNLOCK_ = "Level unlocked_";

    public static void SetMasterVolume(float volume)
    {
        //Volume Setup
        if(volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    //Level Setup
    public static void UnlockLevel(int level)
    {
        if (level <= Application.loadedLevel - 1)
        {
            PlayerPrefs.SetInt(LEVEL_UNLOCK_ + level.ToString(), level);
        }
        else
        {
            Debug.LogError("Trying to load not built level");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCK_ + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);
        if (level <= Application.loadedLevel - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to load not built level");
            return false;
        }
    }
    //Difficulty Setup
    public static void SetLevelDifficulty (float difficulty)
    {
        if(difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(LEVEL_DIFFICULTY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is not valid between 0-1");
        }
    }
    public static float GetLevelDifficulty()
    {
        return PlayerPrefs.GetFloat(LEVEL_DIFFICULTY);
    }
}
