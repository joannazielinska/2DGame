using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMove : MonoBehaviour {

	private Rigidbody2D rigidbody2d;

	public float jumpHigh;
	public float speed;
	public float friction;

	void Awake() {
		rigidbody2d = GetComponent<Rigidbody2D>();
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
			rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
		}

	}
}
