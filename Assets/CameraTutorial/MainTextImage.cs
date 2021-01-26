using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTextImage : MonoBehaviour
{
    
    private Text targetText;
    [SerializeField]
    private Text _text = null;

    [SerializeField]
    private Image top = null;
    [SerializeField]
    private Image arrow = null;
    //[SerializeField]
    //private Image next = null;

    [SerializeField]
    private GameObject next = null;

    [SerializeField]
    private Image CBlock = null;
    [SerializeField]
    private Image RBlock = null;
    [SerializeField]
    private Image FBlock = null;

    [SerializeField]
    private CameraTutorial CT = null;

    private void Update()
    {
        if (CT.MainText == 1)
        {
            First();
        }else if (CT.MainText==2)
        {
            Second();
        }else if (CT.MainText == 3)
        {
            Third();
        }else if (CT.MainText == 4)
        {
            Fourth();
        }
    }

    public void First()
    {
        this.targetText = _text;
        this.targetText.text = "カメラボタンをタップしてルービックキューブを撮影してみましょう。";
        top.enabled = false;
        arrow.enabled = true;
        next.SetActive(false);
        arrow.transform.localPosition = new Vector3(-15,-480,0);
        CBlock.enabled = false;
        RBlock.enabled = true;
        FBlock.enabled = true;
    }

    public void Second()
    {
        this.targetText = _text;
        this.targetText.text = "このようにルービックキューブの色を大きく誤認識したときは撮り直しボタンを押してみましょう。";
        top.enabled = false;
        arrow.enabled = true;
        arrow.transform.localPosition = new Vector3(-40, -290, 0);
        CBlock.enabled = true;
        RBlock.enabled = false;
        FBlock.enabled = true;
    }
    public void Third()
    {
        this.targetText = _text;
        this.targetText.text = "撮り直しボタンを押すと直前に撮影した面の色をリセットすることができます。" +
            "もう一度カメラボタンをタップしてみましょう。";
        top.enabled = false;
        arrow.enabled = true;
        arrow.transform.localPosition = new Vector3(-15, -480, 0);
        CBlock.enabled = false;
        RBlock.enabled = true;
        FBlock.enabled = true;
    }
    public void Fourth()
    {
        this.targetText = _text;
        this.targetText.text = "左上のパネルだけ誤認識してしまいました。このようにルービックキューブの色を一箇所だけ誤認識したときは色修正ボタンを押してみましょう。";
        top.enabled = false;
        arrow.enabled = true;
        arrow.transform.localPosition = new Vector3(-280, -690, 0);
        CBlock.enabled = true;
        RBlock.enabled = true;
        FBlock.enabled = false;
    }
}
