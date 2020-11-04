using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    //　アイテムメニューを開くボタン
    [SerializeField]
    private GameObject StopButton;
    //　ゲーム再開ボタン
    [SerializeField]
    private GameObject RestartButton;
    //　アイテムメニューパネル
    [SerializeField]
    private GameObject RestartPanel;

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
}
