using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rotateInfoButton : MonoBehaviour
{
    public GameObject rotateinfo;
    public GameObject[] canvas;
    public Text prebText = null;
    public Text nextText = null;

    private state s = state.menu;
    public enum state {
        menu=0,
        basicKnowledge=1,
        usage=2,
    }

    private string[] guideTexts = new string[8]{"タイトルに戻る","メニュー","基礎知識編","解法編1","解法編2","解法編3","アプリの見方","タイトルに戻る"};

    void Awake()
    {
        Debug.Log("tutorialキューブ初期化");
        StaticCubeInfo.c.SetComplete();
    }

    void Start()
    {
        Debug.Log("ok");
        SetCanvas(state.menu);
    }

    private void allinactivate() {
        foreach (GameObject c in canvas) {
            c.SetActive(false);
        }
    }

    public void openInfo()
    {
        Debug.Log("open");
        allinactivate();
        rotateinfo.SetActive(true);
    }

   
    public void closeInfo()
    {
        Debug.Log("close");
        rotateinfo.SetActive(false);
        SetCanvas(s);
    }

    public void Next() {
        Debug.Log("next");
        if (rotateinfo.activeSelf) ;
        else if ((int)s == canvas.Length-1)SceneManager.LoadScene("title");
        else
        {
            s++;
            allinactivate();
            canvas[(int)s].SetActive(true);
            prebText.text = guideTexts[(int)s];
            nextText.text = guideTexts[(int)s + 2];
        }
    }

    public void Prev()
    {
        
        Debug.Log("preb");

        if (rotateinfo.activeSelf) ;
        else if (s == 0)SceneManager.LoadScene("title");
        else
        {
            s--;
            allinactivate();
            canvas[(int)s].SetActive(true);
            prebText.text = guideTexts[(int)s ];
            nextText.text = guideTexts[(int)s + 2];
        }
        Debug.Log(s);
    }

    public void SetCanvas(state name)
    {
        s = name;
        allinactivate();
        canvas[(int)s].SetActive(true);
        prebText.text = guideTexts[(int)s ];
        nextText.text = guideTexts[(int)s + 2];
    }



}
