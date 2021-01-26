using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("写真撮影します");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/u.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/r.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/l.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/b.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/f.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/d.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/m.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/e.png");
            Debug.Log("screenshot");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot("Assets/fujisawa/img/s.png");
            Debug.Log("screenshot");
        }
    }
}
