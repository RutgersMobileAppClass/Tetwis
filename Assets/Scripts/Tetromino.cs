using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject cam;

    private bool grace = false;
    private bool blockEnabled = true;
    private Rigidbody2D rb2d;
    //private bool closeEnough = true;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0.0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        checkUserInput();

        if (rb2d.position.y < -20)
        {
            if (blockEnabled)
            {
                FindObjectOfType<Game>().SpawnNextTetromino();
            }
            Destroy(gameObject);
            FindObjectOfType<Game>().reduceLife();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (blockEnabled && !grace)
        {
            StartCoroutine(waitTime());
        }
        if (col != null && col.rigidbody != null)
        {
            col.rigidbody.position = roundOtherPosition(col.rigidbody.position);
        }
    }

    void checkUserInput()
    {
        if (!blockEnabled)
        {
            return;
        }
        // touch 0,0 is at the bottom left
        bool moveRight = false;
        bool moveLeft = false;
        bool moveDown = false;
        bool rotate = false;
        if (Input.touchCount > 0)
        {
            int midH = Screen.width / 2;
            int midV = Screen.height / 2;

            if (Input.GetTouch(0).position.y < midV / 3 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                moveDown = true;
                moveLeft = false;
                moveRight = false;
                rotate = false;
            }
            else if (Input.GetTouch(0).position.y > (midV + midV / 2) && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rotate = true;
                moveDown = false;
                moveLeft = false;
                moveRight = false;
            }
            else if (Input.GetTouch(0).position.x < midH && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                moveLeft = true;
                moveRight = false;
                moveDown = false;
                rotate = false;
            }
            else if (Input.GetTouch(0).position.x > midH && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                moveRight = true;
                moveLeft = true;
                moveDown = false;
                rotate = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight = true;
            moveLeft = true;
            moveDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft = true;
            moveRight = false;
            moveDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown = true;
            moveLeft = false;
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position += new Vector3(1.0f, 0, 0);
        }
        else if (moveLeft)
        {
            transform.position += new Vector3(-1.0f, 0, 0);
        }
        else if (rotate)
        {
            if (gameObject.name.Equals("Prefabs/Tetromino_Square"))
            {
                // do nothing
            }
            else {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (moveDown)
        {
            transform.position += new Vector3(0, -1f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb2d.velocity = new Vector2(0.0f, -speed);
        }
    }

    void roundPosition()
    {
        Vector2 currentPosition = rb2d.position;
        float xPosition = currentPosition.x;
        xPosition = xPosition * 2;
        xPosition = (float)System.Math.Round(xPosition, System.MidpointRounding.AwayFromZero);
        rb2d.position = new Vector2(xPosition / 2, currentPosition.y);
    }

    Vector2 roundOtherPosition(Vector2 pos)
    {
        Vector2 currentPosition = pos;
        float xPosition = currentPosition.x;
        xPosition = xPosition * 2;
        xPosition = (float)System.Math.Round(xPosition, System.MidpointRounding.AwayFromZero);
        return new Vector2(xPosition / 2, currentPosition.y);
    }

    IEnumerator waitTime()
    {
        grace = true;
        yield return new WaitForSeconds(0.3f);
        grace = false;
        blockEnabled = false;
        roundPosition();
        FindObjectOfType<Game>().SpawnNextTetromino();
        rb2d.gravityScale = 1.0f;
        rb2d.mass = rb2d.mass * 1000000;
    }
}