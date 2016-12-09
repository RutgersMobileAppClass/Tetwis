using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	private int lives;
	private int score;

	public Text gameOver;
	// Use this for initialization
	void Start () {
		SpawnNextTetromino (0);
		lives = 1;
	}

	public void SpawnNextTetromino(float height){
		if (height == 0) {
			height = 20.0f;
		}
		string name = GetRandomTetromino ();
		Object o = Resources.Load(name,typeof(GameObject));
		Vector2 location = new Vector2 (0.5f, height);
		GameObject next = (GameObject)Instantiate (o, location, Quaternion.identity);
		next.name = name;
	}

	public void reduceLife(){
		lives = lives - 1;
		if (lives == 0) {
			GameObject[] allTetros = GameObject.FindGameObjectsWithTag("Tetro");  //returns GameObject[]
			float highest = 0;
			float height = 0;
			foreach (GameObject o in allTetros) {
				
				if (o.GetComponent<Rigidbody2D> ().velocity.y < -4.0f) {
				} else {
					height = o.transform.position.y;
					if (height > highest) {
						highest = height;
					}
				}
				o.SetActive (false);
			}
			print ("highest: " + highest);
			score = (int)(highest * 100) + 15;
			print ("score: " + score);
			PlayerPrefs.SetInt("Score", score);
			PlayerPrefs.Save();
			Time.timeScale = 0;
			gameOver.text = "GAME OVER! Score: " + score;
		}
	}
		
	private string GetRandomTetromino(){
		int randomNumber = Random.Range (1, 8);

		string randomTetrominoName = "Tetromino_T";

		switch (randomNumber) {
		case 1:
			randomTetrominoName = "Prefabs/Tetromino_J";
			break;
		case 2:
			randomTetrominoName = "Prefabs/Tetromino_L";
			break;
		case 3:
			randomTetrominoName = "Prefabs/Tetromino_Long";
			break;
		case 4:
			randomTetrominoName = "Prefabs/Tetromino_S";
			break;
		case 5:
			randomTetrominoName = "Prefabs/Tetromino_Square";
			break;
		case 6:
			randomTetrominoName = "Prefabs/Tetromino_T";
			break;
		case 7:
			randomTetrominoName = "Prefabs/Tetromino_Z";
			break;
		}

		return randomTetrominoName;
		//return "Prefabs/Tetromino_Square";
	}
}
