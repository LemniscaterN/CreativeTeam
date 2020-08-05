using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WebCamTest : MonoBehaviour
{
    //private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        WebCamTexture webCamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();

        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //i++;
        //Debug.Log("Update:" + i);
    }
}
