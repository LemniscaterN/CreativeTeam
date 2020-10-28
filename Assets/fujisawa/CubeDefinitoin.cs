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

public class CubeDefinitoin:MonoBehaviour
{
    //マスのId
    //private int[,] picxelId;

    //解法出力の際の優先順位
    //private int[] cornerPicxelPriority;
    //private int[] edgePicxelPriority;

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

}
