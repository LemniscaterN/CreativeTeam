using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Surface_Script : MonoBehaviour
{
    public GameObject Cam;
    public int Surface_num = 0;
    Color color;
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        if (Cam.GetComponent<CamBottun>().Surface == Surface_num)
        {
            //Debug.Log("aaa" + Surface_num);
            float sin = Mathf.Sin(Time.time * 2);

            color.a = Mathf.Abs(sin);

            gameObject.GetComponent<Renderer>().material.color = color;
        }
        else
        {
            color.a = 0.0f;

            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
