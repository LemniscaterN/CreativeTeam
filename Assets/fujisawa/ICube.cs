using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICube
{
    void SetFaceColors(color[,] reciveFaceColors);
    void SetFaceIds(int[,] reciveFaceIds);
    color[,] GetColors();
    int[,] GetFaceIds();
    bool GetColorConsistency();
}
