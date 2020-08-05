using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction_script : MonoBehaviour
{
    private Text targetText;
    public GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cam.GetComponent<CamBottun>().Surface == 0)
        {
            FirstText();
        }else if(Cam.GetComponent<CamBottun>().Surface == 1)
        {
            SecondText();
        }else if(Cam.GetComponent<CamBottun>().Surface == 2)
        {
            ThirdText();
        }else if(Cam.GetComponent<CamBottun>().Surface == 3)
        {
            FourthText();
        }else if(Cam.GetComponent<CamBottun>().Surface == 4)
        {
            FifthText();
        }else if(Cam.GetComponent<CamBottun>().Surface >= 5)
        {
            LastText();
        }
    }

    public void FirstText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "中心が白の面を\n撮ってください"; //最初の面のテキスト(以下テキスト編集可)
    }

    public void SecondText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "二面目";  //二枚目に撮る写真のテキスト
    }

    public void ThirdText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "三面目";　//三枚目に撮る写真のテキスト
    }

    public void FourthText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "四面目";　//四枚目に撮る写真のテキスト
    }

    public void FifthText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "五面目";　//五枚目に撮る写真のテキスト
    }

    public void LastText()
    {
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "六面目（最後）";　//最後に撮る写真のテキスト
    }
}
