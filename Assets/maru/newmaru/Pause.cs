using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{

    //　Pauseを開くボタン
    [SerializeField]
    private GameObject StopButton;
    //　ゲーム再開ボタン
    [SerializeField]
    private GameObject RestartButton;
    //　Pauseパネル
    [SerializeField]
    private GameObject RestartPanel;

    [SerializeField]
    private GameObject hideButton;

    [SerializeField]
    private GameObject displayButton;

    private GameObject Edge;

    private GameObject Corner;

    void Start()
    {
        Time.timeScale = 0f;
        Edge = GameObject.Find("EdgeSolution");
        Corner = GameObject.Find("CornerSolution");
    }


    public void StopGame()
    {
        Time.timeScale = 0f;
        StopButton.SetActive(false);
        RestartButton.SetActive(true);
        RestartPanel.SetActive(true);
    }

    public void RestartGame()
    {
        RestartPanel.SetActive(false);
        RestartButton.SetActive(false);
        StopButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void hidekaiho()
    {
        hideButton.SetActive(false);
        displayButton.SetActive(true);
        Edge.SetActive(false);
        Corner.SetActive(false);
    }

    public void displaykaiho()
    {
        displayButton.SetActive(false);
        hideButton.SetActive(true);
        Corner.SetActive(true);
        Edge.SetActive(true);
    }

    public void backtitle()
    {
        SceneManager.LoadSceneAsync("selectmenu");
    }
}
