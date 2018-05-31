using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBehaviour : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
	public int force;
	public float upreach;
	public static float spawnTime;
	private Transform tramsform;
	private int direction;
	private GameObject lastSpawned;

	void Start () {
		tramsform = GetComponent<Transform>();
		direction = 1;
		lastSpawned = GameObject.Find("Bubble");
		InvokeRepeating("SpawnBubble", spawnTime, spawnTime);

	}
	
	void SpawnBubble () {
		GameObject newBubble;
		newBubble = Instantiate(prefab, new Vector3(tramsform.position.x, transform.position.y, 0), Quaternion.identity);
		Rigidbody2D body = newBubble.GetComponent<Rigidbody2D>();
		body.AddForce(new Vector2(upreach * direction, force));
		lastSpawned.SetActive(false);
		lastSpawned = newBubble;
		direction *= -1;
	}
}
