using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour {
    string Next_Mino;
    private int lives;
    private int score;
    public Text gameOver;
    public int mode;
    static int flag = 0;
    public static float timeleft = 60;
    float highest = 0;
    float height = 20.0f;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;
        Next_Mino = GetRandomTetromino();
        SpawnNextTetromino();
        mode = PlayerPrefs.GetInt("Mode");
        lives = 30000;
        if(mode == 1)
            lives = 5;
    }
	
	// Update is called once per frame
	void Update () {
        if (mode == 2)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0)
                flag = 1;
        }
    }
    void OnGUI()
    {
        if (mode == 2)
        {
            if (timeleft > 0)
            {
                GUI.Label(new Rect(300, 100, 200, 200), "Time: " + Mathf.FloorToInt(timeleft));
            }
            else {
                GUI.Label(new Rect(300, 100, 200, 100), "TIME'S UP");
                lives = 1;
                reduceLife();
            }
        }
    }
    public void SpawnNextTetromino()
    {
        float heightx = 0;
        GameObject[] allTetros = GameObject.FindGameObjectsWithTag("Tetro");  //returns GameObject[]
        foreach (GameObject oo in allTetros)
        {
            if (oo.GetComponent<Rigidbody2D>().velocity.y < -4.0f)
            {
            }
            else {
                heightx = oo.transform.position.y;
                if (heightx > highest)
                {
                    highest = heightx;
                }
            }
        }
        if (highest > height - 5)
            height = highest+1;


        string name = Next_Mino;
        Object o = Resources.Load(name, typeof(GameObject));
        Vector2 location = new Vector2(0.5f, height);
        GameObject next = (GameObject)Instantiate(o, location, Quaternion.identity);
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


    public void reduceLife()
    {
        lives = lives - 1;
        if (lives == 0)
        {
            GameObject[] allTetros = GameObject.FindGameObjectsWithTag("Tetro");  //returns GameObject[]
            float highest = 0;
            float height = 0;
            foreach (GameObject o in allTetros)
            {
                if (o.GetComponent<Rigidbody2D>().velocity.y < -4.0f)
                {
                }
                else {
                    height = o.transform.position.y;
                    if (height > highest)
                    {
                        highest = height;
                    }
                }
                o.SetActive(false);
            }
            print("highest: " + highest);
            score = (int)(highest * 100) + 15;
            print("score: " + score);
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}

