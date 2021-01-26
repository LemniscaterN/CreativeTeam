using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectmenu : MonoBehaviour
{
    [SerializeField]
    private GameObject trainingButton;

    [SerializeField]
    private GameObject showsolutionButton;

    [SerializeField]
    private GameObject titileButton;


    public void training()
    {
        SceneManager.LoadSceneAsync("training");
    }

    public void showsolution()
    {
        SceneManager.LoadSceneAsync("SolutionScene");
    }

    public void titile()
    {
        SceneManager.LoadSceneAsync("title");
    }
}
