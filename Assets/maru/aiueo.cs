using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiueo : MonoBehaviour
{
    [SerializeField]
    private float time = 0.27f;//再生時間
    private AudioSource[] Gojuon;//50音の音声が入っている
    private string[] kana = new string[]
    {
        "あ", "い", "う", "え", "お",
        "か", "き", "く", "け", "こ",
        "さ", "し", "す", "せ", "そ",
        "た", "ち", "つ", "て", "と",
        "な", "に", "ぬ", "ね", "の",
        "は", "ひ", "ふ", "へ", "ほ",
        "ま", "み", "む", "め", "も",
        "や", "ゆ", "よ",
        "ら", "り", "る", "れ", "ろ",
        "わ", "を", "ん"
    };

    void Start()
    {
        Gojuon = gameObject.GetComponents<AudioSource>();
    }
    
    //50音
    public void aiuevoice(string x)
    {
        for (int i = 0; i < Gojuon.Length; i++) 
        {
            if (x == kana[i])
            {
                StartCoroutine(Voice(i,time));
                break;
            }
        }
    }

    IEnumerator Voice(int i,float j)
    {
        Gojuon[i].Play();
        yield return new WaitForSeconds(j);
        Gojuon[i].Stop();
        yield break;
    }
    
    /*テスト用
    [SerializeField]
    float waitTime = 0.6f;
    IEnumerator test()
    {

        for (int i = 0; i < Gojuon.Length; i++)
        {
            Gojuon[i].Play();
            yield return new WaitForSeconds(waitTime);
        }
        yield break;
    }

    void Update ()
    {

       if (Input.GetKey(KeyCode.Space))
       {
            StartCoroutine("test");
            //aiuevoice("あ");
        }

       if (Input.GetKey(KeyCode.Return))
       {
            aiuevoice("る");
       }
    }*/
}