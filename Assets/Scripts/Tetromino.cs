using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour{
	private bool enabled = true;
    private bool onTheFly = false;
    private bool inGrace = false;
    private Rigidbody2D rb2d;
	private float mass;
	private GameObject light;
    private GameObject temi;
    private Vector2 forceLeft;
    private Vector2 forceRight;

    // Use this for initialization
    void Start (){
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0.0f, -5.0f);
		mass = rb2d.mass;
        forceLeft = new Vector2(-1, 0);
        forceRight = new Vector2(1, 0);
        //rb2d.inertia = 1.0f;

    }

	// Update is called once per frame
	void Update (){
		checkUserInput ();
		if (rb2d.velocity.y > -5.0f) {
			rb2d.velocity = rb2d.velocity - new Vector2(0.0f,0.5f);
		}
		if (rb2d.position.y < -12) {
			if (enabled) {
				FindObjectOfType<Game> ().SpawnNextTetromino();
			}
			Destroy (gameObject);
		}
			
	}

	void checkUserInput (){
		if (!enabled) {
			return;
		}

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (onTheFly)
                rb2d.AddForce(forceRight, ForceMode2D.Impulse);
            else
                transform.position += new Vector3 (1.0f, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            if (onTheFly)
                rb2d.AddForce(forceLeft, ForceMode2D.Impulse);
            else
                transform.position += new Vector3 (-1.0f, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (0, 0, 90);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			rb2d.velocity = new Vector2 (0.0f,-15.0f);
        } else if (Input.GetKeyUp(KeyCode.DownArrow)){
			rb2d.velocity = new Vector2(0.0f,-5.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (enabled && !inGrace) {
            StartCoroutine(grace());
		}
	}
    IEnumerator grace()
    {
        inGrace = true;
        //Wait one second after the first collision and allow user to make on-the-fly corrections
        //Then cut off the user actions and make a new block
        yield return new WaitForSecondsRealtime(0.5f);
        onTheFly = true;
        enabled = false;
        FindObjectOfType<Game>().SpawnNextTetromino();
        rb2d.mass = rb2d.mass * 1000000;
        inGrace = false;
    }

    void OnTriggerStay2D(){
		//cam = (Camera) GameObject.FindGameObjectWithTag ("MainCamera");
		//cam.transform.position = cam.transform.position + new Vector3 (0.0f, 5.0f);
	}

	void OnTriggerExit2D(){
		
	}
		
}
