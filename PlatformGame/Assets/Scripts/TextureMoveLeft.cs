using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMoveLeft : MonoBehaviour {

    public float speed;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0.0f);
    }
}
