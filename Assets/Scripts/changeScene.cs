using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class changeScene : MonoBehaviour {

    public void loadLevel(int a)
    {
        if (a == 0)
            SceneManager.LoadSceneAsync("main_screen", LoadSceneMode.Single);
        if (a == 1)
        {
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Single);
            PlayerPrefs.SetInt("Mode", 1);
        }
        if (a == 2)
        {
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Single);
            PlayerPrefs.SetInt("Mode", 2);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
