using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public SpriteRenderer backgroundSpriteRenderer;
	public Sprite[] backgroundSprites;

	// Use this for initialization
	void Start () {

		backgroundSpriteRenderer.sprite = backgroundSprites [Random.Range (0, backgroundSprites.Length)];


	}
	
	// Update is called once per frame
	void Update () {
	}


}


