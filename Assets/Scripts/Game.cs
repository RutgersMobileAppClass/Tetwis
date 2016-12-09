using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour {
    string Next_Mino;



	// Use this for initialization
	void Start ()
    {
        Next_Mino = GetRandomTetromino();
        SpawnNextTetromino(0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }
	
	// Update is called once per frame
	void Update () {
	}


	public void SpawnNextTetromino(float height){
		if (height == 0) {
			height = 18.0f;
		}
		string name = Next_Mino;
		Object o = Resources.Load(name,typeof(GameObject));
		Vector2 location = new Vector2 (0.5f, height);
		GameObject next = (GameObject)Instantiate (o, location, Quaternion.identity);
		next.name = name;
        Next_Mino = GetRandomTetromino();
        //Update the Next Mino Button
        if (GameObject.FindWithTag("Next_Mino") != null)
        {
            string nameOfTexture = Next_Mino + " 1";
            Object o2 = Resources.Load(nameOfTexture, typeof(GameObject));
            GameObject nextMinoButton = GameObject.FindWithTag("Next_Mino");
            Vector3 nextLocation = nextMinoButton.transform.position;
            Destroy(nextMinoButton);
            nextMinoButton = (GameObject)Instantiate(o2, nextLocation, Quaternion.identity);
            nextMinoButton.tag = "Next_Mino";
        }
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
		//return "Prefabs/Tetromino_Z";
	}
		
}
