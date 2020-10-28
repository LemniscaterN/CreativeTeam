using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICube 
{
    void SetFaceColors(color[,] reciveFaceColors);
    color[,] GetColors();
    int[,] GetFaceIds();
}
