using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Transform rightBound;

    private Vector3 boundPos;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        boundPos = new Vector3(rightBound.position.x - 0.5f, rightBound.position.y, rightBound.position.z);
    }

    void LateUpdate()
    {
        Vector3 newPos = transform.position + offset;

        if (newPos.x < boundPos.x)
            transform.position = player.transform.position + offset;
    }
}
