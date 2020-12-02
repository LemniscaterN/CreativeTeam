using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    [SerializeField]
    private Material green = null;
    [SerializeField]
    private Material red = null;
    [SerializeField]
    private Material blue = null;
    [SerializeField]
    private Material orange = null;
    [SerializeField]
    private Material white = null;
    [SerializeField]
    private Material yellow = null;
    /*[SerializeField]
    private Material gray = null;*/


    public void changecolor(color cal)
    {
        if (cal == color.green)
        {
            this.gameObject.GetComponent<Renderer>().material = green;
        }
        if (cal == color.red)
        {
            this.gameObject.GetComponent<Renderer>().material = red;
        }
        if (cal == color.blue)
        {
            this.gameObject.GetComponent<Renderer>().material = blue;
        }
        if (cal == color.orange)
        {
            this.gameObject.GetComponent<Renderer>().material = orange;
        }
        if (cal == color.white)
        {
            this.gameObject.GetComponent<Renderer>().material = white;
        }
        if (cal == color.yellow)
        {
            this.gameObject.GetComponent<Renderer>().material = yellow;
        }
        /*if (cal == color.unset)
        {
            this.gameObject.GetComponent<Renderer>().material = gray;
        }*/


    }
}
