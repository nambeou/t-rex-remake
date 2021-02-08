using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    Material material;
    Vector2 offset;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        updateOffset();
    }

    void Update()
    {
        updateOffset();
        material.mainTextureOffset += offset*Time.deltaTime;
    }

    private void updateOffset() {
        float currentSpeed = FindObjectOfType<GameSession>().GetGameSpeed();
        offset = new Vector2 (currentSpeed, 0);

    }
}
