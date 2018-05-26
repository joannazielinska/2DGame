using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float oldPosY = transform.position.y;
        float oldPosZ = transform.position.z;

        transform.position = player.transform.position + offset;
    }
}
