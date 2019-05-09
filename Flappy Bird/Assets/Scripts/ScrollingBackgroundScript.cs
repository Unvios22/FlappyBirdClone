using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundScript : MonoBehaviour {
    
    [SerializeField] private float scrollingSpeed = 1f;
    [SerializeField] private Renderer bgRenderer;

    private void Update(){
        bgRenderer.material.mainTextureOffset += new Vector2(scrollingSpeed * Time.deltaTime, 0f);
        //add offset each frame to move the texture on renderer
    }
}
