using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
    マスのIdはGoogleDoc参照。

    ・public string GetPixelNameFromId(int id);
    　マスのIdから対応する文字列（平仮名）を取得。範囲外なら文字列「WA(+受け取ったid)」を返す

    ・将来的に文字列を変更出来るようにする。（予定）
*/

public class CubeDefinitoin　:MonoBehaviour
{
    //マスのId
    //private int[,] picxelId;

    //解法出力の際の優先順位
    //private int[] cornerPicxelPriority;
    //private int[] edgePicxelPriority;

    void Awake()
    {
        //ここでテキストから呼び出し予定
    }

    //マスの名前 ひらがながデフォ
    private string[,] PixelName= new string[6,9] {
            {"け","て","せ","け","　C　","せ","く","つ","す"},
            {"れ","ら","ら","れ","　C　","り","る","る","り"},
            {"さ","た","か","し","　C　","き","し","ち","き"},
            {"な","な","ね","に","　C　","ね","に","ぬ","ぬ"},
            {"た","さ","て","あ","　C　","え","あ","か","え"},
            {"い","く","う","い","　C　","う","ち","す","つ"},
     };

    public string GetPixelNameFromId(int id) {
        if (id < 0 || id > 58 || id%10==9) return ("WA:"+id);
        int f = id / 10;
        int p = id % 10;
        
        return PixelName[f, p];
    }

    //CubeIdとPixelIdの相互関係
    public int[][] GetEdgePairIds()
    {
        int[][] edgeInclude = new int[12][] {
            new int[2]{1,45} ,new int[2]{3,35} ,new int[2]{5,13} ,new int[2]{7,55},
            new int[2]{21,43},new int[2]{23,15},new int[2]{25,33},new int[2]{27,53},
            new int[2]{11,41},new int[2]{17,57},
            new int[2]{31,47},new int[2]{37,51}
        };
        return edgeInclude;
    }


    //時計回りのID
    public int[][] GetCornerTrioIds()
    {
        int[][] cornerInclude = new int[8][] {
            new int[3]{0,32,48} ,new int[3]{2,42,10} ,new int[3]{8,16,58} ,new int[3]{6,52,38},
            new int[3]{20,12,40},new int[3]{22,46,30},new int[3]{26,56,18},new int[3]{28,36,50}
        };
        return cornerInclude;
    }

    //バッファーのキューブID取得
    public int[] GetCornerBufferPixelIds(bool truely = false)
    {
        if (truely) return new int[1] { 46 };
        return new int[3] { 46, 22, 30 };
    }
    public int[] GetEdgeBufferPixelIds(bool truely = false)
    {
        if (truely) return new int[1] { 41 };
        return new int[2] { 41, 11 };
    }
}
