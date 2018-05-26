using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Transform leftBounds;
    public Transform rightBounds;

    public float smootDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;

    private float camWidth, camHeight, levelMinX, levelMaxX;
    
	void Start () {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        float leftBoundWidth = leftBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x /2;
        float rightBoundWidth = rightBounds.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        levelMinX = leftBounds.position.x + leftBoundWidth + (camWidth / 2);
        levelMaxX = rightBounds.position.x - rightBoundWidth - (camWidth / 2);
    }
	
	void Update () {

        if (target)
        {
            float targetX = Mathf.Max(levelMinX, Mathf.Max ( levelMaxX, target.position.x));

            float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smootDampTime);

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
	}
}
