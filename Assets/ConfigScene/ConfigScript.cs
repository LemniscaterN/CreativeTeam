using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    [SerializeField]
    private Text volumeSize = null;
    [SerializeField]
    private Text SetUpText = null;
    [SerializeField]
    private Text SwapText = null;

    static public int variablevol = 0;
    static public int vol = 10 - variablevol;

    private void Awake()
    {
        vol = 10 - variablevol;
        volumeSize.text = "" + vol + "";

        if (TrigerManager3.SkipSetUp == true)
        {
            SetUpText.text = "ON";
        }
        else if (TrigerManager3.SkipSwap == false)
        {
            SetUpText.text = "OFF";
        }

        if (TrigerManager3.SkipSwap == true)
        {
            SwapText.text = "ON";
        }
        else if (TrigerManager3.SkipSwap == false)
        {
            SwapText.text = "OFF";
        }
    }

    public void plusVolme()
    {
        if (vol < 10)
        {
            variablevol--;
            vol = 10 - variablevol;

            volumeSize.text = "" + vol + "";
        }
        //Debug.Log("aaa");
    }

    public void minusVolume()
    {
        if (vol > 0)
        {
            variablevol++;
            vol = 10 - variablevol;
            volumeSize.text = "" + vol + "";
        }
        //Debug.Log("aaa");
    }

    public void SwitchSetUp()
    {
        TrigerManager3.SkipSetUp = !TrigerManager3.SkipSetUp;
        if (TrigerManager3.SkipSetUp == true)
        {
            SetUpText.text = "ON";
        }else if (TrigerManager3.SkipSetUp==false)
        {
            SetUpText.text = "OFF";
        }
    }

    public void SwitchSwap()
    {
        TrigerManager3.SkipSwap = !TrigerManager3.SkipSwap;
        if (TrigerManager3.SkipSwap == true)
        {
            SwapText.text = "ON";
        }else if (TrigerManager3.SkipSwap==false)
        {
            SwapText.text = "OFF";
        }
    }
}
