using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public static float timeleft = 60;
	public static int timetime;
    private int mode;

	// Use this for initialization
	void Start () {
        mode = PlayerPrefs.GetInt("Mode");
	}
	
	// Update is called once per frame
	void Update () {
        if(mode == 2)
    		timeleft -= Time.deltaTime;
	}

	void OnGUI(){
        if (mode == 2)
        {
            if (timeleft > 0)
            {
                GUI.Label(new Rect(300, 100, 200, 200), "Time: " + Mathf.FloorToInt(timeleft));
            }
            else {
                GUI.Label(new Rect(300, 100, 200, 100), "TIME'S UP");
                SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
            }
        }
	}
}
