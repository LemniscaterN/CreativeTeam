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

    public List<int> GetEdgeSolution() {
        return edgeSolution;
    }

    public List<int> GetCornerSolution()
    {
        return cornerSolution;
    }

    public bool MakeSolution(Cube c)
    {
        int [,]faceIds = c.GetFaceIds();
        if (c.GetColorConsistency() == false) return false;

        bool isOKEdge = MakeEdgeSolutino(faceIds);
        bool isOKCorner = MakeCornerSolution(faceIds);

        if (!isOKEdge || !isOKCorner) {
            edgeSolution.RemoveRange(0, edgeSolution.Count-1);
            cornerSolution.RemoveRange(0, cornerSolution.Count-1);
            return false;
        } 


        //CubeDefinitoin cb = gameObject.GetComponent<CubeDefinitoin>();

        //Debug.Log("解法表示:");
        //foreach (var id in edgeSolution) {
        //    Debug.Log($"Edge id:{id} 平仮名:{cb.GetPixelNameFromId(id)}");
        //}
        //foreach (var id in cornerSolution)
        //{
        //    Debug.Log($"Corn id:{id} 平仮名:{cb.GetPixelNameFromId(id)}");
        //}

        return true;
    }

    //エッジキューブとコーナーキューブに番号を振る
    private int GetCubeIdFromPixelId(int pixelId)
    {
        int[][] edgeInclude = GetEdgePairIds();
        int[][] cornerInclude = GetCornerTrioIds(); ;
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
        edgeInclude = GetEdgePairIds();
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
        cornerInclude = GetCornerTrioIds();
        int Id = -1;
        for (int i = 0; i < cornerInclude.Length; i++)
        {
            Id = Array.IndexOf(cornerInclude[i], pixelId);
            if (Id >= 0) return true;
        }
        return false;
    }

    private bool IsEdgeBufferCubeId(int id,bool truely = false)
    {
        int[] ids = GetEdgeBufferPixelIds();
        if (truely && id==ids[0])return true;
        if (!truely && (id == ids[0] || id == ids[1])) return true;
        return false;
    }

    private bool IsCornerBufferCubeId(int id, bool truely = false)
    {
        int[] ids = GetCornerBufferPixelIds();
        if (truely && id == ids[0]) return true;
        if (!truely && (id == ids[0] || id == ids[1] || id== ids[2])) return true;
        return false;
    }

    //解放出力の優先順位id
    private int[] GetCornerPriority() {
        int[] priority = new int[24];
        int[] cornerNumbers = new int[4] {0,2,6,8};
        int NowCnt = 0;
        for (int f = 0; f < 6; f++) {
            foreach(int p in cornerNumbers){
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
            for (int p = 1; p < 9; p+=2) {
                priority[NowCnt] = f * 10 + p;
                NowCnt++;
            }
        }
        return priority;
    }

    //CubeIdとPixelIdの相互関係
    private int[][] GetEdgePairIds() {
        int[][] edgeInclude = new int[12][] {
            new int[2]{1,45} ,new int[2]{3,35} ,new int[2]{5,13} ,new int[2]{7,55},
            new int[2]{21,43},new int[2]{23,15},new int[2]{25,33},new int[2]{27,53},
            new int[2]{11,41},new int[2]{17,57},
            new int[2]{31,47},new int[2]{37,51}
        };
        return edgeInclude;
    }
    private int[][] GetCornerTrioIds()
    {
        int[][] cornerInclude = new int[8][] {
            new int[3]{0,32,48} ,new int[3]{2,10,42} ,new int[3]{8,16,58} ,new int[3]{6,38,52},
            new int[3]{20,12,40},new int[3]{22,30,46},new int[3]{26,18,56},new int[3]{28,36,50}
        };
        return cornerInclude;
    }

    int[] GetCornerBufferPixelIds(bool truely = false)
    {
        if (truely) return new int[1] { 46 };
        return new int[3] { 46, 22, 30 };
    }
    int[] GetEdgeBufferPixelIds(bool truely = false)
    {
        if (truely) return new int[1] { 41 };
        return new int[2] { 41, 11 };
    }

    private bool MakeEdgeSolutino(int [,] faceIds) {
        //初期状態での完成具合の確認
        bool[] EachEdgeCompCheck = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
        for (int f = 0; f < 6; f++)
        {
            for (int p = 0; p < 9; p++)
            {
                if (f * 10 + p == faceIds[f, p] && IsEdge(f * 10 + p))EachEdgeCompCheck[GetCubeIdFromPixelId(f * 10 + p)] = true;
            }
        }
        int nextId = -1;
        int edgeProcessCounter = 0;
        int[] edgePriority = GetEdgePriority();
        int nowPriorityEdgeIndex = 0;
        int bufferId = faceIds[GetEdgeBufferPixelIds(true)[0] /10, GetEdgeBufferPixelIds(true)[0]%10];

        //全てのエッジが正しい位置になるまでループ
        while (EachEdgeCompCheck.Count(value => value == true) != EachEdgeCompCheck.Length)
        {
            //破損ルービックキューブのケース
            if (EachEdgeCompCheck.Count(value => value == true) == EachEdgeCompCheck.Length - 1)
            {
                Debug.LogWarning("Solve Edge warning1:1EO is left. Can't solve.");
                return false;
            }

            int startId = bufferId;

            //bufferにあるキューブが既に正しい位置か確認する
            //既に正しい位置ならば優先順位edgePriorityに従ってbufferを未完成箇所と交換する（セットアップ）
            bool bufferChange = false;
            if (IsEdgeBufferCubeId(bufferId))
            {
                while (EachEdgeCompCheck[GetCubeIdFromPixelId(edgePriority[nowPriorityEdgeIndex])] == true || IsEdgeBufferCubeId(edgePriority[nowPriorityEdgeIndex]))
                {
                    nowPriorityEdgeIndex++;
                    if (nowPriorityEdgeIndex >= edgePriority.Length)
                    {
                        Debug.LogWarning("Solve Edge warning2:Priority out of range.");
                        return false;
                    }
                }
                bufferChange = true;
                startId = edgePriority[nowPriorityEdgeIndex];
                edgeSolution.Add(startId);
                edgeProcessCounter++;
            }

            //bufferから繋がる箇所をSolutionにAddする。移動先がスタート位置なら終了
            int nf = startId / 10;
            int np = startId % 10;
            EachEdgeCompCheck[GetCubeIdFromPixelId(startId)] = true;
            nextId = faceIds[nf, np];
            while (true)
            {
                edgeSolution.Add(nextId);
                edgeProcessCounter++;
                EachEdgeCompCheck[GetCubeIdFromPixelId(nextId)] = true;
                nf = nextId / 10;
                np = nextId % 10;
                if (faceIds[nf, np] == startId) break;
                nextId = faceIds[nf, np];
            }

            //bufferのキューブを変更していたら戻す（逆セットアップ）
            //そうで無ければbufferをループの終了地点に更新する
            if (bufferChange)
            {
                edgeSolution.Add(startId);
                edgeProcessCounter++;
            }
            else bufferId = nextId;

            //bufferにあるキューブが正しい位置ならフラグを立てる
            if (IsEdgeBufferCubeId(bufferId, true)) EachEdgeCompCheck[GetCubeIdFromPixelId(bufferId)] = true;            

        }

        //奇数回の時は偶数になるように修正
        if (edgeProcessCounter % 2 == 1)
        {
            edgeSolution.Add(47);
            edgeSolution.Add(43);
            edgeSolution.Add(47);
        }

        return true;
    }

    bool MakeCornerSolution(int [,]faceIds) {
        //初期状態での完成具合の確認
        bool[] EachCornerCompCheck = new bool[8] { false, false, false, false, false, false, false, false};
        for (int f = 0; f < 6; f++)
        {
            for (int p = 0; p < 9; p++)
            {
                if (f * 10 + p == faceIds[f, p] && IsCorner((f * 10 + p)))EachCornerCompCheck[GetCubeIdFromPixelId(f * 10 + p)] = true;
            }
        }

        int nextId = -1;
        int[] cornerPriority = GetCornerPriority();
        int nowPriorityCornerIndex = 0;
        int bufferId = faceIds[GetCornerBufferPixelIds(true)[0] / 10, GetCornerBufferPixelIds(true)[0] % 10];

        while (EachCornerCompCheck.Count(value => value == true) != EachCornerCompCheck.Length)
        {
            if (EachCornerCompCheck.Count(value => value == true) == EachCornerCompCheck.Length - 1)
            {
                Debug.LogWarning("Solve Corner warning1:1EO is left. Can't solve.");
                return false;
            }

            int startId = bufferId;

            //bufferの部分が完成しているかEOしている
            bool bufferChange = false;
            if (IsCornerBufferCubeId(bufferId))
            {
                while (EachCornerCompCheck[GetCubeIdFromPixelId(cornerPriority[nowPriorityCornerIndex])] == true || IsCornerBufferCubeId(cornerPriority[nowPriorityCornerIndex]))
                {
                    nowPriorityCornerIndex++;
                    if (nowPriorityCornerIndex >= cornerPriority.Length)
                    {
                        Debug.LogWarning("Solve Corner warning2:Priority out of range.");
                        return false;
                    }
                }
                bufferChange = true;
                startId = cornerPriority[nowPriorityCornerIndex];
                cornerSolution.Add(startId);
            }

            
            int nf = startId / 10;
            int np = startId % 10;
            EachCornerCompCheck[GetCubeIdFromPixelId(startId)] = true;
            nextId = faceIds[nf, np];

            while (true)
            {
                cornerSolution.Add(nextId);
                EachCornerCompCheck[GetCubeIdFromPixelId(nextId)] = true;
                nf = nextId / 10;
                np = nextId % 10;
                if (faceIds[nf, np] == startId) break;
                nextId = faceIds[nf, np];
            }

            if (bufferChange)cornerSolution.Add(startId);
            else bufferId = nextId;
            
            if (IsCornerBufferCubeId(bufferId, true)) EachCornerCompCheck[GetCubeIdFromPixelId(bufferId)] = true;

        }
        return true;
    }



}
