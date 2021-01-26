using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlebutton : MonoBehaviour
{ //CameraSceneへの遷移

    public void StartButton()
    {
        SceneManager.LoadScene("CameraScene");
    }
    public void ConfigButton()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    public void tutorialButton()
    {
        SceneManager.LoadScene("Cameratutorial");
    }

    public void solutionTutorial()
    {
        SceneManager.LoadScene("solutionTutorial");
    }
}
