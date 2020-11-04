using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
/*
    注意：CubeDefnition.csを同一オブジェクトにアタッチする必要あり。

    ・public void SetFaceColors(color[,] reciveFaceColors)
        [6,9]のcolorの多重配列を渡すと、渡されたcolorsと対応するfaceIdsを持つ。存在しない色の組み合わせは-1が設定される。
        この際、ルービックキューブの整合性についてはそれほど考慮しない。

    ・public void SetFaceIds(int[,] reciveFaceIds)
        [6,9]のintの多重配列を渡すと、重複IDがなければ内部に保持する。
        この際、ルービックキューブの整合性についてはそれほど考慮しない。
    
    ・public color[,] GetColors()
        SetColorsで渡された色の配列を返す。SetColorsが呼び出されていないなら全て緑になる。

    ・public int[,] GetFaceIds()
        SetColorsで渡された色をIdに変換した配列を返す。SetColorsが呼び出されていないなら全て0になる。

    ・public bool GetColorConsistency()
        同一IDを持つキューブや、あり得ない色の組み合わせがあるならtrueを返す。
*/


public class Cube : MonoBehaviour,ICube
{
    private color[,] faceColors = new color[6, 9];
    private int[,] faceIds = new int[6, 9];

 
    private CubeDefinitoin cd;

    void Awake()
    {
        cd = GetComponent<CubeDefinitoin>();    
    }

    //同一キューブの存在確認
    private bool colorConsistency= true;

    public color[,] GetColors() { return faceColors; }
    public int[,] GetFaceIds() { return faceIds; }
    public bool GetColorConsistency() { return colorConsistency; }

    public void SetFaceIds(int[,] reciveFaceIds) {
        bool[] pixelIdMap = new bool[60];
        for (int i = 0; i < 60; i++)pixelIdMap[i] = false;
        for (int f = 0; f < 6; f++) {
            for (int p = 0; p < 9; p++) {
                pixelIdMap[reciveFaceIds[f, p]] = true;
            }
        }

        //for (int f = 0; f < 6; f++)
        //{
        //    for (int p = 0; p < 9; p++)
        //    {
        //        Debug.Log($"{f*10+p} {pixelIdMap[f * 10 + p]}");
        //    }
        //}


        if (pixelIdMap.Count(value => value == true) == 54)
        {
            faceIds = reciveFaceIds;
        }
        else Debug.LogWarning("同一キューブが複数存在！:"+ pixelIdMap.Count(value => value == true));
    }

    public void SetFaceColors(color[,] reciveFaceColors) {
        //同一IDを持つキューブが無いか確認する
        bool[] pixelIdMap = new bool[60];
        for (int i = 0; i < 60; i++) {
            pixelIdMap[i] = false;
        }
        

        //色の保存
        faceColors = reciveFaceColors;

        //センターキューブの確認
        for (int f = 0; f < 6; f++) {
            if ((int)reciveFaceColors[f, 4] == f) {
                pixelIdMap[f * 10 + 4] = true;
                faceIds[f, 4] = f * 10 + 4;
            }
        }

        
        //エッジのペア列挙
        Tuple<Tuple<int, int>, Tuple<int, int>>[] edgeFP = new Tuple<Tuple<int, int>, Tuple<int, int>>[12]
        {
            //緑面
            Tuple.Create(Tuple.Create(0,1), Tuple.Create(4,5)),
            Tuple.Create(Tuple.Create(0,3), Tuple.Create(3,5)),
            Tuple.Create(Tuple.Create(0,5), Tuple.Create(1,3)),
            Tuple.Create(Tuple.Create(0,7), Tuple.Create(5,5)),
            ////青面
            Tuple.Create(Tuple.Create(2,1), Tuple.Create(4,3)),
            Tuple.Create(Tuple.Create(2,3), Tuple.Create(1,5)),
            Tuple.Create(Tuple.Create(2,5), Tuple.Create(3,3)),
            Tuple.Create(Tuple.Create(2,7), Tuple.Create(5,3)),

            //サイド
            Tuple.Create(Tuple.Create(1,1), Tuple.Create(4,1)),
            Tuple.Create(Tuple.Create(1,7), Tuple.Create(5,7)),

            Tuple.Create(Tuple.Create(3,1), Tuple.Create(4,7)),
            Tuple.Create(Tuple.Create(3,7), Tuple.Create(5,1)),
        };
        for (int i = 0; i < edgeFP.Length; i++) {
            int f1 = edgeFP[i].Item1.Item1;
            int p1 = edgeFP[i].Item1.Item2;
            int f2 = edgeFP[i].Item2.Item1;
            int p2 = edgeFP[i].Item2.Item2;
            int[] pairEdgeId = getEdgeIdsFromColors(reciveFaceColors[f1, p1], reciveFaceColors[f2, p2]);
            faceIds[f1, p1] = pairEdgeId[0];
            faceIds[f2, p2] = pairEdgeId[1];
            if (pairEdgeId[0] < 0 || pairEdgeId[1] < 0) colorConsistency = false;
            else {
                pixelIdMap[pairEdgeId[0]] = true;
                pixelIdMap[pairEdgeId[1]] = true;
            }
        }

        //コーナーのペア列挙
        Tuple<int, int>[,] cornerFP = new Tuple<int, int>[8, 3]{
            //緑
            { Tuple.Create(0, 2), Tuple.Create(1, 0), Tuple.Create(4, 2)},
            { Tuple.Create(0, 8), Tuple.Create(1, 6), Tuple.Create(5, 8)},
            { Tuple.Create(0, 6), Tuple.Create(3, 8), Tuple.Create(5, 2)},
            { Tuple.Create(0, 0), Tuple.Create(3, 2), Tuple.Create(4, 8)},
            //青
            { Tuple.Create(2, 0), Tuple.Create(1, 2), Tuple.Create(4, 0)},
            { Tuple.Create(2, 2), Tuple.Create(3, 0), Tuple.Create(4, 6)},
            { Tuple.Create(2, 6), Tuple.Create(1, 8), Tuple.Create(5, 6)},
            { Tuple.Create(2, 8), Tuple.Create(3, 6), Tuple.Create(5, 0)},
        };

        for (int i = 0; i < 8; i++) {
            int f1 = cornerFP[i, 0].Item1;
            int p1 = cornerFP[i, 0].Item2;
            int f2 = cornerFP[i, 1].Item1;
            int p2 = cornerFP[i, 1].Item2;
            int f3 = cornerFP[i, 2].Item1;
            int p3 = cornerFP[i, 2].Item2;
            //Debug.Log($"{reciveFaceColors[f1, p1]} {reciveFaceColors[f2, p2]} {reciveFaceColors[f3, p3]}");
            int[] cornerIds = getCornerIdsFromColors(reciveFaceColors[f1, p1], reciveFaceColors[f2, p2], reciveFaceColors[f3, p3]);
            faceIds[f1, p1] = cornerIds[0];
            faceIds[f2, p2] = cornerIds[1];
            faceIds[f3, p3] = cornerIds[2];
            //Debug.Log($"{cornerIds[0]} {cornerIds[1]} {cornerIds[2]}");
            if (cornerIds[0] < 0 || cornerIds[1] < 0 || cornerIds[2] < 0) colorConsistency = false;
            else {
                pixelIdMap[cornerIds[0]] = true;
                pixelIdMap[cornerIds[1]] = true;
                pixelIdMap[cornerIds[2]] = true;
            }
        }

        //重複IDがあるならfalse
        if (pixelIdMap.Count(value => value == true) != 54)
        {
            colorConsistency = false;
            //Debug.Log("重複アリ:" + pixelIdMap.Count(value => value == true));
            //for (int f = 0; f < 6; f++)
            //    for (int p = 0; p < 9; p++) Debug.Log($"{f * 10 + p} {pixelIdMap[f * 10 + p]}");
        }

        ////キューブのid表示
        //for (int f = 0; f < 6; f++)
        //{
        //    Debug.Log("f:" + f);
        //    Debug.Log($"{faceIds[f, 0]} {faceIds[f, 1]} {faceIds[f, 2]} {faceIds[f, 3]} {faceIds[f, 4]} {faceIds[f, 5]} {faceIds[f, 6]} {faceIds[f, 7]} {faceIds[f, 8]}");
        //}

    }


    private int[] getCornerIdsFromColors(color c1,color c2,color c3) {
        int[] ids = new int[3] {-1,-1,-1};
        color[] colors = new color[3] {c1,c2,c3};
        bool green  = 0 <= Array.IndexOf(colors, color.green);
        bool red    = 0 <= Array.IndexOf(colors, color.red);
        bool blue   = 0 <= Array.IndexOf(colors, color.blue);
        bool orange = 0 <= Array.IndexOf(colors, color.orange);
        bool white  = 0 <= Array.IndexOf(colors, color.white);
        bool yellow = 0 <= Array.IndexOf(colors, color.yellow);
        if (green && red    && white )    ids = setCornerIds(colors, 2,10,42);
        if (green && red    && yellow)    ids = setCornerIds(colors, 8,16,58);
        if (green && orange && white )    ids = setCornerIds(colors, 0,32,48);
        if (green && orange && yellow)    ids = setCornerIds(colors, 6,38,52);
        if (blue  && red    && white )    ids = setCornerIds(colors,20,12,40);
        if (blue  && red    && yellow)    ids = setCornerIds(colors,26,18,56);
        if (blue  && orange && white )    ids = setCornerIds(colors,22,30,46);
        if (blue  && orange && yellow)    ids = setCornerIds(colors,28,36,50);
        return ids;
    }
    
    private int[] getEdgeIdsFromColors(color c1,color c2) {
        //Debug.Log($"{c1} {c2}");

        int[] ids = new int[2] { -1, -1 };
        bool swapFlag = false;
        if (c1 > c2) {
            color temp = c1;
            c1 = c2;
            c2 = temp;
            swapFlag = true;
        }

        if (c1 == color.green) {
            if (c2 == color.red) ids = setEdgeIds(5, 13);
            if (c2 == color.orange) ids = setEdgeIds(3, 35);
            if (c2 == color.yellow) ids = setEdgeIds(7, 55);
            if (c2 == color.white) ids = setEdgeIds(1, 45);
        }
        if (c1 == color.red)
        {
            if (c2 == color.blue) ids = setEdgeIds(15, 23);
            if (c2 == color.yellow) ids = setEdgeIds(17, 57);
            if (c2 == color.white) ids = setEdgeIds(11, 41);
        }
        if (c1 == color.blue)
        {
            if (c2 == color.orange) ids = setEdgeIds(25, 33);
            if (c2 == color.yellow) ids = setEdgeIds(27, 53);
            if (c2 == color.white) ids = setEdgeIds(21, 43);
        }
        if (c1 == color.orange)
        {
            if (c2 == color.yellow) ids = setEdgeIds(37, 51);
            if (c2 == color.white) ids = setEdgeIds(31, 47);
        }

        if (swapFlag == true) {
            int temp=ids[0];
            ids[0] = ids[1];
            ids[1] = temp;
        }
        return ids;
    }

    private int[] setEdgeIds(int a, int b) {
        int[] ids = new int[2];
        ids[0] = a;
        ids[1] = b;
        return ids;
    }

    private int[] setCornerIds(color[] colors,int id1,int id2, int id3)
    {
        int[] settedIds = new int[3];
        int[] ids = new int[3] {id1,id2,id3};
        for (int c = 0; c < 3; c++) {
            for (int i = 0; i < 3; i++)
            {
                if ((int)(colors[c]) == ids[i] / 10) {
                    settedIds[c] = ids[i];
                    break;
                }
            }
        }
        return settedIds;
    }


    public bool SwapCube(int f1,int f2) {
        if (f1 % 2 != f2 % 2 || (f1 % 10 == 4 || f2 % 10 == 4)) return false;
        if (f1 < 0 || f2 < 0 || f1 > 58 || f2 > 58) return false;

        bool isEdge = true;
        if (f1 % 2 == 0) isEdge = false;
        
        int[][] cubeIds;
        int CUBE_COUNT;
        int CUBE_INCLUDES_PIXELCOUNT;
        if (isEdge)
        {
            cubeIds = cd.GetEdgePairIds();
            CUBE_COUNT = 12;
            CUBE_INCLUDES_PIXELCOUNT=2;
        }
        else {
            cubeIds = cd.GetCornerTrioIds();
            CUBE_COUNT = 8;
            CUBE_INCLUDES_PIXELCOUNT=3;
        }
        
        int cubeId1 = -1, cubeId2 = -1;
        int cubeIndex1 = -1, cubeIndex2 = -1;
        for (int i = 0; i < CUBE_COUNT; i++)
        {
            if (cubeId1 == -1)
            {
                int f1i = Array.IndexOf(cubeIds[i], f1);
                if (f1i >= 0)
                {
                    cubeId1 = i;
                    cubeIndex1 = f1i;
                }
            }
            if (cubeId2 == -1)
            {
                int f2i = Array.IndexOf(cubeIds[i], f2);
                if (f2i >= 0)
                {
                    cubeId2 = i;
                    cubeIndex2 = f2i;
                }
            }
        }

        if (cubeId1 == -1 || cubeId2 == -1 || cubeIndex1 == -1 || cubeIndex2 == -1)
        {
            return false;
        }

        if (cubeId1 == cubeId2)
        {
            return false;
        }

        for (int p = 0; p < CUBE_INCLUDES_PIXELCOUNT; p++)
        {
            int fo1 = cubeIds[cubeId1][(cubeIndex1 + p) % CUBE_INCLUDES_PIXELCOUNT];
            int fo2 = cubeIds[cubeId2][(cubeIndex2 + p) % CUBE_INCLUDES_PIXELCOUNT];
            int tempId = faceIds[fo1 / 10, fo1 % 10];
            faceIds[fo1 / 10, fo1 % 10] = faceIds[fo2 / 10, fo2 % 10];
            faceIds[fo2 / 10, fo2 % 10] = tempId;
        }
        return true;
    }


    /*



    以降はテスト用


     
     */

    public void ShowCube2(int [,]faceIds2)
    {
        for (int f = 0; f < 6; f++)
        {
            Debug.Log("面:" + f);
            Debug.Log($"{faceIds2[f, 0]} {faceIds2[f, 1]} {faceIds2[f, 2]} {faceIds2[f, 3]} {faceIds2[f, 4]} {faceIds2[f, 5]} {faceIds2[f, 6]} {faceIds2[f, 7]} {faceIds2[f, 8]}");
        }
    }

    public void ShowCube() {
        for (int f = 0; f < 6; f++)
        {
            Debug.Log("面:" + f);
            Debug.Log($"{faceIds[f, 0]} {faceIds[f, 1]} {faceIds[f, 2]} {faceIds[f, 3]} {faceIds[f, 4]} {faceIds[f, 5]} {faceIds[f, 6]} {faceIds[f, 7]} {faceIds[f, 8]}");
        }
    }

  }
