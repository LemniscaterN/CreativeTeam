using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onlycharacter : MonoBehaviour
{
    private SolCharFactory scf;

    // Start is called before the first frame update
    void Start()
    {
        //StaticCubeInfo.TestSet(); 
        scf = GetComponent<SolCharFactory>();
        scf.CreateSolutionText();
        //Debug.Log("文字だけ成功");
    }
}
