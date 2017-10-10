using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadTime = 5;

    private void Start()
    {
        if(autoLoadTime <= 0)
        {
            Debug.Log("Auto Load Next lvl Canceled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadTime);
        }

    }

    public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        //Application.LoadLevel(Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
