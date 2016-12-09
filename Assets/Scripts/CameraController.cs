using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private int hereToStay = 0;
	private Vector3 increment = new Vector3(0f,0.01f,0);
	private bool inOriginalPosition = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		//print ("enter");
		hereToStay++;
		StartCoroutine (moveCamera ());
	}

	void OnTriggerExit2D(Collider2D col){
		//print ("im out fam");
		hereToStay--;
	}
		
	IEnumerator moveCamera(){
		//print ("waiting a sec now");
		yield return new WaitForSeconds (3.0f);
		//print ("value is : " + hereToStay);
		if (hereToStay >= 1 && inOriginalPosition) {
			for (int i = 0; i < 5000; i++) {
				transform.position += increment;
			}
			inOriginalPosition = false;
		} else if (hereToStay == 0 && !inOriginalPosition) {
			for (int i = 0; i < 500; i++) {
				transform.position -= increment;
			}
			inOriginalPosition = true;
		}
	}
}