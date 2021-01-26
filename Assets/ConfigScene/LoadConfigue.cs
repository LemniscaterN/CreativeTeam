using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadConfigue : MonoBehaviour
{
    private void Awake()
    {
        ConfigScript.variablevol = PlayerPrefs.GetInt("volume");

        if (PlayerPrefs.GetInt("setup") == 0)
        {
            TrigerManager3.SkipSetUp = false;
        }else if (PlayerPrefs.GetInt("setup") == 1)
        {
            TrigerManager3.SkipSetUp = true;
        }

        if (PlayerPrefs.GetInt("swap") == 0)
        {
            TrigerManager3.SkipSwap = false;
        }else if (PlayerPrefs.GetInt("swap") == 1)
        {
            TrigerManager3.SkipSwap = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            PlayerPrefs.DeleteAll();

        }
    }
}
