using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndlessGame : MonoBehaviour {

	private static float time;
	static int flag = 0;
	// Use this for initialization
	void Start () {
		SpawnNextTetromino ();
	
	}
	
	// Update is called once per frame
	void Update () {

		time = Timer.timeleft;
		print (time);
		if (time <= 0) {

			flag = 1;

		}


	}

	void OnGUI(){
	
		if (flag == 1) {


			GUI.Label (new Rect (0, 0, 400, 400), "Gamer Over");
		}
	
	}

	public void SpawnNextTetromino(){


		if (flag == 0) {
			Object o = Resources.Load (GetRandomTetromino (), typeof(GameObject));
			Vector2 location = new Vector2 (0f, 18f);
			GameObject next = (GameObject)Instantiate (o, location, Quaternion.identity);
		} 
		else {


		}
	}

	private string GetRandomTetromino(){
		int randomNumber = Random.Range (1, 8);

		string randomTetrominoName = "Tetromino_T";

		switch (randomNumber) {
		case 1:
			randomTetrominoName = "Prefabs2/Tetromino_J";
			break;
		case 2:
			randomTetrominoName = "Prefabs2/Tetromino_L";
			break;
		case 3:
			randomTetrominoName = "Prefabs2/Tetromino_Long";
			break;
		case 4:
			randomTetrominoName = "Prefabs2/Tetromino_S";
			break;
		case 5:
			randomTetrominoName = "Prefabs2/Tetromino_Square";
			break;
		case 6:
			randomTetrominoName = "Prefabs2/Tetromino_T";
			break;
		case 7:
			randomTetrominoName = "Prefabs2/Tetromino_Z";
			break;
		}
		return randomTetrominoName;
		//return "Prefabs/Tetromino_Square";
	}
}
