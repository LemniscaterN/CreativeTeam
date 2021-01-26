using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCubeInfo:MonoBehaviour
{
    public static Cube c;
    public static Solve s;
    public static CubeDefinitoin cd;

    void Awake() {
        Debug.Log("Static CubeInfo初期化");
        cd = GetComponent<CubeDefinitoin>();
        s = GetComponent<Solve>(); 
        c = GetComponent<Cube>();

        //TestCubeArray tcu = new TestCubeArray();
        //OpenCvSharp.CubeInspection.colorArray = tcu.getB2();
    }

    //trigermanagerと競合するとバグるので注意
    void Start()
    {
        TestSet();
    }

    public static void TestSet()
    {
        Debug.Log("Static要素でのテストケース");
        TestCubeArray tcu = new TestCubeArray();

        c.SetFaceColors(tcu.getB2());
        s.MakeSolution(c);
    }

}
