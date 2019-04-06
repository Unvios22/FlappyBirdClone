using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundScript : MonoBehaviour
{
    [SerializeField] private float bgSpeed = 1f;
    [SerializeField] private Renderer bgRenderer;

    private void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}
