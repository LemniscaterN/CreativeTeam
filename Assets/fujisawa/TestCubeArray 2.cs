using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubeArray
{

    public color[,] getCompColors()
    {
        color[,] colors = new color[6, 9];
        for (int f = 0; f < 6; f++)
        {
            for (int p = 0; p < 9; p++)
            {
                colors[f, p] = (color)f;
            }
        }

        return colors;
    }

    //エッジ単一ループ
    public color[,] getShColors1()
    {
        //く か　解法かく
        color[,] colors = getCompColors();
        colors[1, 1] = color.orange;
        colors[4, 7] = color.yellow;
        colors[3, 7] = color.red;
        colors[5, 1] = color.white;
        return colors;
    }


    //エッジ複数ループ
    public color[,] getShColors2()
    {
        //作成：くかく　きけき　解法 ：けきけ　なぬな
        color[,] colors = getCompColors();
        colors[4, 7] = color.yellow;
        colors[2, 5] = color.green;
        colors[5, 1] = color.white;
        colors[0, 3] = color.blue;
        return colors;
    }

    //buffer対面ペアEO
    public color[,] getShColors3()
    {
        //かなか　解法　かなか
        color[,] colors = getCompColors();
        colors[1, 1] = color.white;
        colors[4, 1] = color.red;

        colors[4, 7] = color.orange;
        colors[3, 1] = color.white;
        return colors;
    }

    //buffer対面ペアEO + 1ペアEO（完成不可能）
    public color[,] getShColors4()
    {
        //かなか　解法　かなか
        color[,] colors = getCompColors();
        colors[1, 1] = color.white;
        colors[4, 1] = color.red;

        colors[4, 7] = color.orange;
        colors[3, 1] = color.white;

        colors[3, 7] = color.yellow;
        colors[5, 1] = color.orange;
        return colors;
    }

    //コーナー　複数ループ
    public color[,] getShColors5()
    {
        color[,] colors = getCompColors();
        colors[2, 6] = color.orange;
        colors[2, 8] = color.red;

        colors[3, 6] = color.blue;
        colors[3, 8] = color.green;

        colors[0, 6] = color.red;
        colors[0, 8] = color.orange;

        colors[1, 6] = color.green;
        colors[1, 8] = color.blue;
        return colors;
    }

    //エラーだったヤツ
    //エッジ：2ループ+かあか　15　33 37 5 35 47 / 1 57 1 /47 43 47
    //コーナ：2
    public color[,] getShColors6()
    {
        color[,] colors = getCompColors();
        colors[0, 0] = color.red;
        colors[0, 1] = color.yellow;
        colors[0, 2] = color.orange;

        colors[0, 3] = color.orange;
        colors[0, 4] = color.green;
        colors[0, 5] = color.orange;

        colors[0, 6] = color.blue;
        colors[0, 7] = color.green;
        colors[0, 8] = color.green;

        colors[1, 0] = color.yellow;
        colors[1, 1] = color.blue;
        colors[1, 2] = color.blue;

        colors[1, 3] = color.green;
        colors[1, 4] = color.red;
        colors[1, 5] = color.orange;

        colors[1, 6] = color.red;
        colors[1, 7] = color.white;
        colors[1, 8] = color.green;

        colors[2, 0] = color.red;
        colors[2, 1] = color.blue;
        colors[2, 2] = color.orange;
        colors[2, 3] = color.blue;
        colors[2, 4] = color.blue;
        colors[2, 5] = color.yellow;
        colors[2, 6] = color.white;
        colors[2, 7] = color.blue;
        colors[2, 8] = color.yellow;

        colors[3, 0] = color.green;
        colors[3, 1] = color.red;
        colors[3, 2] = color.white;
        colors[3, 3] = color.orange;
        colors[3, 4] = color.orange;
        colors[3, 5] = color.white;
        colors[3, 6] = color.blue;
        colors[3, 7] = color.green;
        colors[3, 8] = color.orange;

        colors[4, 0] = color.yellow;
        colors[4, 1] = color.red;
        colors[4, 2] = color.green;
        colors[4, 3] = color.white;
        colors[4, 4] = color.white;
        colors[4, 5] = color.red;
        colors[4, 6] = color.white;
        colors[4, 7] = color.white;
        colors[4, 8] = color.blue;

        colors[5, 0] = color.orange;
        colors[5, 1] = color.red;
        colors[5, 2] = color.white;
        colors[5, 3] = color.yellow;
        colors[5, 4] = color.yellow;
        colors[5, 5] = color.yellow;
        colors[5, 6] = color.red;
        colors[5, 7] = color.green;
        colors[5, 8] = color.yellow;

        return colors;
    }

    public int[,] getShColors7() {
        int[,] cubes = new int[6,9] {

            {48,53,30,47,4,1,58,55,42 },
            {46,11,28,45,14,21,10,51,18},
            {50,57,20,43,24,25,26,13,6},
            {40,15,0,33,34,31,52,3,16},
            {36,41,22,17,44,27,12,23,32},
            {38,35,8,5,54,7,56,37,2}

        };
        return cubes;
    }
}
