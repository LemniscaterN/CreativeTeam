using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeArrayTest : MonoBehaviour
{
    
    private color[,] faceColors;

    color[,] getCompColors() {
        color[,] colors = new color[6, 9];
        for (int f = 0; f < 6; f++) {

            for (int p = 0; p < 9; p++)
            {
                colors[f, p] = (color)f;
            }
        }
        return colors;
    }

    color[,] getRandomColors()
    {
        color[,] colors = new color[6, 9];
        for (int f = 0; f < 6; f++)
        {

            for (int p = 0; p < 9; p++)
            {
                if (p == 4) {
                    colors[f, p] = (color)((f+1)%6);
                }
            }
        }
        return colors;
    }

}
