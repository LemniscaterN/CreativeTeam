using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/*
利用出来るメソッド
    ・public bool MakeSolution(Cube c);
      解法を作成する。解法を作成することが出来たらtrue、失敗したらfalse

    ・public List<int> GetEdgeSolution();
      エッジキューブの解法リストを返す。MakeSolutionにてfalse、もしくはMakeSolutionが呼び出されていないなら空リストを返す

    ・public List<int> GetCornerSolution();
      コーナーキューブの解法リストを返す。MakeSolutionにてfalse、もしくはMakeSolutionが呼び出されていないなら空リストを返す

    注：解法リストには各マスに振られたIDが格納される。CubeDefinitionのメソッドで対応する文字列（平仮名）を取得可能。
*/

public class Solve : MonoBehaviour
{
    private List<int> edgeSolution = new List<int>();
    private List<int> cornerSolution = new List<int>();

    private CubeDefinitoin cd =　null;

    void Awake()
    {
        cd = gameObject.GetComponent<CubeDefinitoin>();
        //TestCubeArray tca = new TestCubeArray();
        //Debug.Log("Awake!!");
        //Cube cb = new Cube();
        //cb.SetFaceIds(tca.getShColors7());
        //cb.ShowCube();
        //MakeSolution(cb);
    }

    public List<int> GetEdgeSolution()
    {
        return edgeSolution;
    }

    public List<int> GetCornerSolution()
    {
        return cornerSolution;
    }

    public bool MakeSolution(Cube c)
    {
        int[,] faceIds = c.GetFaceIds();
        if (c.GetColorConsistency() == false)
        {
            Debug.Log("ColorConsistency false");
            return false;
        }


        bool isOKEdge = MakeEdgeSolutino(faceIds);
        bool isOKCorner = MakeCornerSolution(faceIds);
        if (!isOKEdge || !isOKCorner)
        {
            Debug.Log($"解法出力エラー！　Edge:{isOKEdge} Corner:{isOKCorner}");
            if(edgeSolution.Count>0) edgeSolution.RemoveRange(0, edgeSolution.Count - 1);
            if (cornerSolution.Count > 0) cornerSolution.RemoveRange(0, cornerSolution.Count - 1);
            return false;
        }

        Debug.Log("解法表示:");
        foreach (var id in edgeSolution)
        {
            Debug.Log($"Edge id:{id} 平仮名:{cd.GetPixelNameFromId(id)}");
        }
        foreach (var id in cornerSolution)
        {
            Debug.Log($"Corn id:{id} 平仮名:{cd.GetPixelNameFromId(id)}");
        }

        return true;
    }

    //エッジキューブとコーナーキューブに番号を振る
    private int GetCubeIdFromPixelId(int pixelId)
    {
        int[][] edgeInclude = cd.GetEdgePairIds();
        int[][] cornerInclude = cd.GetCornerTrioIds(); ;
        for (int i = 0; i < 12; i++)
        {
            int index = Array.IndexOf(edgeInclude[i], pixelId);
            if (index >= 0) return i;
        }
        for (int i = 0; i < 8; i++)
        {
            int index = Array.IndexOf(cornerInclude[i], pixelId);
            if (index >= 0) return i;
        }
        return -1;
    }


    private bool IsEdge(int pixelId)
    {
        int[][] edgeInclude = new int[12][];
        edgeInclude = cd.GetEdgePairIds();
        int Id = -1;
        for (int i = 0; i < edgeInclude.Length; i++)
        {
            Id = Array.IndexOf(edgeInclude[i], pixelId);
            if (Id >= 0) return true;
        }
        return false;
    }

    private bool IsCorner(int pixelId)
    {
        int[][] cornerInclude = new int[8][];
        cornerInclude = cd.GetCornerTrioIds();
        int Id = -1;
        for (int i = 0; i < cornerInclude.Length; i++)
        {
            Id = Array.IndexOf(cornerInclude[i], pixelId);
            if (Id >= 0) return true;
        }
        return false;
    }

    private bool IsEdgeBufferCubeId(int id, bool truely = false)
    {
        int[] ids = cd.GetEdgeBufferPixelIds();
        if (truely && id == ids[0]) return true;
        if (!truely && (id == ids[0] || id == ids[1])) return true;
        return false;
    }

    private bool IsCornerBufferCubeId(int id, bool truely = false)
    {
        int[] ids = cd.GetCornerBufferPixelIds();
        if (truely && id == ids[0]) return true;
        if (!truely && (id == ids[0] || id == ids[1] || id == ids[2])) return true;
        return false;
    }

    //解放出力の優先順位id
    private int[] GetCornerPriority()
    {
        int[] priority = new int[24];
        int[] cornerNumbers = new int[4] { 0, 2, 6, 8 };
        int NowCnt = 0;
        for (int f = 0; f < 6; f++)
        {
            foreach (int p in cornerNumbers)
            {
                priority[NowCnt] = f * 10 + p;
                NowCnt++;
            }
        }
        return priority;
    }
    private int[] GetEdgePriority()
    {
        int[] priority = new int[24];
        int NowCnt = 0;
        for (int f = 0; f < 6; f++)
        {
            for (int p = 1; p < 9; p += 2)
            {
                priority[NowCnt] = f * 10 + p;
                NowCnt++;
            }
        }
        return priority;
    }

    private bool IsSameCornerCube(int a, int b)
    {
        int[][] cornerInclude = new int[8][];
        cornerInclude = cd.GetCornerTrioIds();
        for (int i = 0; i < cornerInclude.Length; i++)
        {
            int Id1 = Array.IndexOf(cornerInclude[i], a);
            int Id2 = Array.IndexOf(cornerInclude[i], b);
            if (Id1 >= 0 && Id2 >= 0) return true;
        }
        return false;
    }

    private bool MakeEdgeSolutino(int[,] faceIds)
    {

        int bufferPixelId = cd.GetEdgeBufferPixelIds(true)[0];
        int bufferFace = bufferPixelId / 10;
        int bufferPixel = bufferPixelId % 10;

        Cube solver = new Cube();
        solver.SetFaceIds(faceIds);
        
        int[,] solverFaceIds = solver.GetFaceIds();

        //初期状態での完成具合の確認 ただし、bufferのみ常にfalse
        bool[] EachEdgeCompCheck = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
        for (int f = 0; f < 6; f++)
        {
            for (int p = 0; p < 9; p++)
            {
                if (f * 10 + p == solverFaceIds[f, p] && IsEdge(f * 10 + p)) EachEdgeCompCheck[GetCubeIdFromPixelId(f * 10 + p)] = true;
            }
        }
        EachEdgeCompCheck[GetCubeIdFromPixelId(bufferPixelId)] = false;



        int edgeProcessCounter = 0;
        int[] edgePriority = GetEdgePriority();
        int nowPriorityEdgeIndex = 0;

        //buffer以外の全てのエッジが正しい位置になるまでループ
        while (EachEdgeCompCheck.Count(value => value == true) != EachEdgeCompCheck.Length-1)
        {
            solverFaceIds = solver.GetFaceIds();
            int startId = solverFaceIds[bufferFace, bufferPixel];
            //Debug.Log("StartId:"+startId);

            //bufferにあるキューブが既に正しい位置か確認する
            //既に正しい位置ならば優先順位edgePriorityに従ってbufferを未完成箇所と交換する

            if (IsEdgeBufferCubeId(startId))
            {
                
                while (EachEdgeCompCheck[GetCubeIdFromPixelId(edgePriority[nowPriorityEdgeIndex])] == true || IsEdgeBufferCubeId(edgePriority[nowPriorityEdgeIndex]))
                {
                    nowPriorityEdgeIndex++;
                    //Debug.Log($"{nowPriorityEdgeIndex} Max:{edgePriority.Length}");
                    //if (nowPriorityEdgeIndex < edgePriority.Length) Debug.Log(edgePriority[nowPriorityEdgeIndex]);

                    if (nowPriorityEdgeIndex >= edgePriority.Length)
                    {
                        //プライオリティーリストの異常
                        Debug.LogWarning("Solve Edge warning2:Priority cube out of range.");
                        return false;
                    }
                }
                startId = edgePriority[nowPriorityEdgeIndex];
                edgeSolution.Add(startId);
                //Debug.LogWarning("交換" + startId);
                edgeProcessCounter++;
                solver.SwapCube(startId,bufferPixelId);
            }

            //bufferから繋がる箇所をSolutionにAddする。
            while (true)
            {
                //現在のbuffer
                solverFaceIds = solver.GetFaceIds();
                int swapTargetId = solverFaceIds[bufferFace, bufferPixel];

                //移動先がスタート位置なら終了
                if (IsEdgeBufferCubeId(swapTargetId)) break;

                //交換
                EachEdgeCompCheck[GetCubeIdFromPixelId(swapTargetId)] = true;
                solver.SwapCube(swapTargetId, bufferPixelId);
                edgeSolution.Add(swapTargetId);
                //Debug.LogWarning(swapTargetId);
                edgeProcessCounter++;
            }

            //Debug.Log("loop");

        }

             //buffer以外が完成している時、bufferを確認する。
            solverFaceIds = solver.GetFaceIds();
            for (int i = 0; i < 8; i++)
            {
                if (EachEdgeCompCheck[i] == false)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        if (GetCubeIdFromPixelId(k) == i) Debug.Log(k);
                    }
                    break;
                }
            }

            if (IsEdgeBufferCubeId(solverFaceIds[bufferFace, bufferPixel], true))
            {
                Debug.Log("エッジOK");
            }
            else
            {
                Debug.LogWarning("Solve Edge warning1:1EO is left. Can't solve.");
                return false;
            }

        //奇数回の操作の時は偶数になるように修正
        if (edgeProcessCounter % 2 == 1)
        {
            edgeSolution.Add(47);
            edgeSolution.Add(43);
            edgeSolution.Add(47);
        }

        return true;
    }

    private bool MakeCornerSolution(int[,] faceIds)
    {

        Cube solver = new Cube();
        solver.SetFaceIds(faceIds);

        int[,] solverFaceIds = solver.GetFaceIds();
        int bufferPixelId = cd.GetCornerBufferPixelIds(true)[0];
        int bufferFace = bufferPixelId / 10;
        int bufferPixel = bufferPixelId % 10;


        //初期状態での完成具合の確認
        bool[] EachCornerCompCheck = new bool[8] { false, false, false, false, false, false, false, false };
        for (int f = 0; f < 6; f++)
        {
            for (int p = 0; p < 9; p++)
            {
                if (f * 10 + p == solverFaceIds[f, p] && IsCorner(f * 10 + p)) EachCornerCompCheck[GetCubeIdFromPixelId(f * 10 + p)] = true;
            }
        }
        EachCornerCompCheck[GetCubeIdFromPixelId(bufferPixelId)] = false;
        
        int[] cornerPriority = GetCornerPriority();
        int nowPriorityEdgeIndex = 0;

        while (EachCornerCompCheck.Count(value => value == true) != EachCornerCompCheck.Length-1)
        {
            
            int startId = solverFaceIds[bufferFace, bufferPixel];

            if (IsCornerBufferCubeId(startId))
            {

                while (EachCornerCompCheck[GetCubeIdFromPixelId(cornerPriority[nowPriorityEdgeIndex])] == true || IsCornerBufferCubeId(cornerPriority[nowPriorityEdgeIndex]))
                {
                    nowPriorityEdgeIndex++;
                    if (nowPriorityEdgeIndex >= cornerPriority.Length)
                    {
                        //プライオリティーリストの異常
                        Debug.LogWarning("Solve Edge warning2:Priority cube out of range.");
                        return false;
                    }
                }

                startId = cornerPriority[nowPriorityEdgeIndex];
                cornerSolution.Add(startId);
                solver.SwapCube(startId, bufferPixelId);
            }

            //bufferから繋がる箇所をSolutionにAddする。移動先がスタート位置なら終了            
            while (true)
            {
                solverFaceIds = solver.GetFaceIds();
                int swapTargetId = solverFaceIds[bufferFace, bufferPixel];
                if (IsCornerBufferCubeId(swapTargetId)) break;

                EachCornerCompCheck[GetCubeIdFromPixelId(swapTargetId)] = true;
                solver.SwapCube(swapTargetId, bufferPixelId);

                cornerSolution.Add(swapTargetId);
            }
            
        }


        solverFaceIds = solver.GetFaceIds();
        if (IsCornerBufferCubeId(solverFaceIds[bufferFace, bufferPixel], true))
        {
            Debug.Log("コーナーOK");    
        }
        else
        {
            Debug.LogWarning("Solve Corner warning1:1EO is left. Can't solve.");
            return false;
        }
        

        return true;
    }

}
