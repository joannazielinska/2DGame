using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private int direction;
	private Rigidbody2D rigidbody2d;
	public SpriteRenderer spriteRenderer; 
	public float speed;
	// public int playerDamage;

	void Start() {
		direction = -1;
		rigidbody2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();


	}

	void Update () {
		rigidbody2d.velocity = new Vector2(speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		direction *= (-1);
		speed *= direction;
		spriteRenderer.flipX = !spriteRenderer.flipX;
	
	}
}
