using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpawnNextTetromino ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnNextTetromino(){
		Object o = Resources.Load(GetRandomTetromino(),typeof(GameObject));
		Vector2 location = new Vector2 (0f, 20f);
		GameObject next = (GameObject)Instantiate (o, location, Quaternion.identity);
	}

	private string GetRandomTetromino(){
		int randomNumber = Random.Range (1, 8);

		string randomTetrominoName = "Tetromino_T";

		switch (randomNumber) {
		case 1:
                //randomTetrominoName = "Prefabs/Tetromino_J";
                randomTetrominoName = "Prefabs/Leaves_J";
                break;
		case 2:
                //randomTetrominoName = "Prefabs/Tetromino_L";
                randomTetrominoName = "Prefabs/Purple_L";
			break;
		case 3:
                //randomTetrominoName = "Prefabs/Tetromino_Long";
                randomTetrominoName = "Prefabs/Brick_Long";
                break;
		case 4:
                //randomTetrominoName = "Prefabs/Tetromino_S";
                randomTetrominoName = "Prefabs/Orange_S";
                break;
		case 5:
                //randomTetrominoName = "Prefabs/Tetromino_Square";
                randomTetrominoName = "Prefabs/Ice_Square";
                break;
		case 6:
                //randomTetrominoName = "Prefabs/Tetromino_T";
                randomTetrominoName = "Prefabs/Concrete_T";
                break;
		case 7:
                //randomTetrominoName = "Prefabs/Tetromino_Z";
                randomTetrominoName = "Prefabs/Wood_Z";
                break;
		}
		return randomTetrominoName;
		//return "Prefabs/Tetromino_Square";
	}
}
