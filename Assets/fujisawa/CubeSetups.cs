using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;

public class CubeSetups : MonoBehaviour
{
    static public List<RotateDef>[] SetUpList = new List<RotateDef>[59];
    static public List<RotateDef>[] RSetUpList = new List<RotateDef>[59];

    public List<RotateDef> GetSetup(int id,bool reve = false) {
        if (id < 0 || id > 58 || id % 10 == 9) return new List<RotateDef>();
        if(reve)return RSetUpList[id];
        List<RotateDef> rv = SetUpList[id];
        return rv;
    }

    void Awake()
    {
        Debug.Log("CubeSetUp start");
        ReadSetUpfile("setup/EdgeSetUp");
        ReadSetUpfile("setup/CornerSetUp");
    }

    private bool ReadSetUpfile(string filenpath) {
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load(filenpath, typeof(TextAsset)) as TextAsset;
        RotateDefTranslator rdt = new RotateDefTranslator();
        if (textasset == null)
        {
            Debug.LogWarning($"{filenpath} is null !");
            return false;
        }
        else
        {
            string TextLines = textasset.text;
            string[] textMessage = TextLines.Split('\n');
            int rowLength = textMessage.Length;
            for (int i = 0; i < rowLength; i++)
            {
                string[] tempWords = textMessage[i].Split(',');
                int columnLength = tempWords.Length;
                int id = Int32.Parse(tempWords[0]);
                SetUpList[id] = new List<RotateDef>();
                RSetUpList[id] = new List<RotateDef>();
                //Debug.Log("id="+id);
                for (int n = 1; n < columnLength; n++)
                {
                    RotateDef rd = rdt.StringToRotateDef(tempWords[n].Replace("P","\'"));//Pを"に置換
                    if (rd == RotateDef.Err)
                    {
                        Debug.LogWarning($"Deetct Err!: ID={id} N={n} in {filenpath}  Err:{tempWords[n]}");
                        return false;
                    }
                    else {
                        //Debug.Log(rd);
                        SetUpList[id].Add(rd);
                        RSetUpList[id].Add(rdt.RotateDefToReverse(rd));
                    }
                    
                }
                RSetUpList[id].Reverse();
            }
        }
        return true;
    }

}  
