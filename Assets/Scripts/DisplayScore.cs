using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        int hs = 0;
        score = GetComponent<Text>();
        int sc = PlayerPrefs.GetInt("Score");
        int mode = PlayerPrefs.GetInt("Mode");

        if (mode == 1)
        {
            score.text = "Your Standard Mode score is: " + sc;
            if (PlayerPrefs.HasKey("Highscore1"))
                hs = PlayerPrefs.GetInt("Highscore1");
            if (sc > hs)
            {
                PlayerPrefs.SetInt("Highscore1", sc);
                score.text = score.text + "! New High Score!";
                PlayerPrefs.Save();
            }
        }
        else if (mode == 2)
        {
            score.text = "Your Time Attack score is: " + sc;
            if (PlayerPrefs.HasKey("Highscore2"))
                hs = PlayerPrefs.GetInt("Highscore2");
            if (sc > hs)
            {
                PlayerPrefs.SetInt("Highscore2", sc);
                score.text = score.text + "! New High Score!";
                PlayerPrefs.Save();
            }
        }
        PlayerPrefs.SetInt("Mode", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
