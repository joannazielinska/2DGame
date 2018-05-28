using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwarfMove : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	private int score;

	public float jumpHigh;
	public float speed;
	public float baseMovement;
	public Text scoreText;

	void Awake() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		score = 0;
		SetScoreText();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
			rigidbody2d.AddForce(new Vector2(0.0f, jumpHigh));
		}
		if (Input.GetButtonDown("Horizontal")) {
			rigidbody2d.AddForce(new Vector2(speed, 0.0f));
			
		}
		// else if (rigidbody2d.velocity.x > 0) {
		// 	rigidbody2d.AddForce(new Vector2(-friction, 0.0f));
		// }
		else {
			rigidbody2d.velocity = new Vector2(baseMovement, rigidbody2d.velocity.y);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Coin")){
			score +=10;
		}
		
		if (other.gameObject.CompareTag("Food")){
			other.gameObject.SetActive(false);
			score +=5;
		}
		SetScoreText();
	
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString();
	}
}
