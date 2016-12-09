using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(AudioSource))]

public class Tetromino_Endless : MonoBehaviour{
	private bool enabled = true;
	private Rigidbody2D rb2d;
	private float mass;
	private GameObject light;
	public AudioClip impact;
	public AudioClip change;
	AudioSource audioContact;
	AudioSource audioSwitch;

	// Use this for initialization
	void Start (){

		audioContact = GetComponent<AudioSource> ();
		audioSwitch = GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (0.0f, -5.0f);
		mass = rb2d.mass;
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
				FindObjectOfType<EndlessGame> ().SpawnNextTetromino();
			}
			Destroy (gameObject);
		}
			
	}

	void checkUserInput (){
		if (!enabled) {
			return;
		}
			
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1.0f, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1.0f, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (0, 0, 90);
			audioSwitch.PlayOneShot (change, 0.7F);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			rb2d.velocity = new Vector2 (0.0f,-15.0f);
		} else if (Input.GetKeyUp(KeyCode.DownArrow)){
			rb2d.velocity = new Vector2(0.0f,-5.0f);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (enabled) {
			enabled = false;

			FindObjectOfType<EndlessGame> ().SpawnNextTetromino ();
			rb2d.mass = rb2d.mass * 1000000;
			audioContact.PlayOneShot (impact, 0.7F);
		}
	}

	void OnTriggerStay2D(){
		//cam = (Camera) GameObject.FindGameObjectWithTag ("MainCamera");
		//cam.transform.position = cam.transform.position + new Vector3 (0.0f, 5.0f);
	}

	void OnTriggerExit2D(){
		
	}
		
}
