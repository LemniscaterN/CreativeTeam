using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixTextImage : MonoBehaviour
{
    private Text targetText;
    [SerializeField]
    private Text _text = null;
    [SerializeField]
    private Image arrow = null;

    [SerializeField]
    private Image BBlock = null;

    [SerializeField]
    private CameraTutorial CT = null;

    private void Update()
    {
        if (CT.FixText == 1)
        {
            FFirst();
        }else if (CT.FixText == 2)
        {
            FSecond();
        }
    }

    public void FFirst()
    {
        this.targetText = _text;
        this.targetText.text = "青色のボタンを押してみましょう。";
        arrow.transform.localPosition = new Vector3(60, -520, 0);
        BBlock.enabled = true;

    }
    public void FSecond()
    {
        this.targetText = _text;
        this.targetText.text = "このように選択したパネルを任意の色に変更することができます。" +
            "また、ルービックキューブの下にある「次の面」、「前の面」のボタンでルービックキューブが回転して面を変更できます。" +
            "左上の戻るボタンで撮影画面に戻ります。戻るボタンを押してみましょう。";
        arrow.transform.localPosition = new Vector3(-150, 400, 0);
        arrow.transform.eulerAngles = new Vector3(0,180,0);
        BBlock.enabled = false;
    }
}
