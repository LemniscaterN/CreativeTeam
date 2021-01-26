using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveStatus : MonoBehaviour
{
    public void savestatus()
    {
        PlayerPrefs.SetInt("volume", ConfigScript.variablevol);
        PlayerPrefs.SetInt("setup", TrigerManager3.SkipSetUp ? 1 : 0);
        PlayerPrefs.SetInt("swap", TrigerManager3.SkipSwap ? 1 : 0);

        SceneManager.LoadScene("title");
    }
}
