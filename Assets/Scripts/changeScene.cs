using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class changeScene : MonoBehaviour {

	public void loadLevel(int a)
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        if (a == 0)
            SceneManager.LoadSceneAsync("main_screen", LoadSceneMode.Single);
        if (a == 1)
            SceneManager.LoadSceneAsync("Level", LoadSceneMode.Single);
        if (a == 2)
            SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Single);
        if (a == 3)
            SceneManager.LoadSceneAsync("Options", LoadSceneMode.Single);

        //SceneManager.UnloadScene(currentScene);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
