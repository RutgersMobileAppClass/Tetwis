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
        score.text = "Your score is: " + sc;
        if(PlayerPrefs.HasKey("Highscore"))
            hs = PlayerPrefs.GetInt("Highscore");
        if (sc > hs)
        {
            PlayerPrefs.SetInt("Highscore", sc);
            score.text = score.text + "! New High Score!";
            PlayerPrefs.Save();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
