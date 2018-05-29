using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	private SpriteRenderer spriteRenderer; 
	public float speed;
	// public int playerDamage;

	void Start() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();


	}

	void Update () {
		rigidbody2d.velocity = new Vector2(speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Tile")){
			speed *= (-1);
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}
		
	
	}
}
