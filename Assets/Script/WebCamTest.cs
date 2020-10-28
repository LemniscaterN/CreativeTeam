using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class WebCamTest : MonoBehaviour
{
    //private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        WebCamTexture webCamTexture = new WebCamTexture();
        //Renderer renderer = GetComponent<Renderer>();
        RawImage _raw = GetComponent<RawImage>();
        //renderer.material.mainTexture = webCamTexture;
        _raw.texture = webCamTexture;
        webCamTexture.Play();

        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
