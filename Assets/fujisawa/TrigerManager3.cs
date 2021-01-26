using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrigerManager3 : MonoBehaviour
{
    //[SerializeField]
    //private CubeSetups cs = null;
    [SerializeField]
    private TriggerScript ts = null;
    [SerializeField]
    public SolCharFactory sc = null;
    [SerializeField]
    private Transform DisplayList = null;
    [SerializeField]
    private Toggle AutoToggle =null;
    [SerializeField]
    private GameObject yesno = null;

    //各種オプション
    public static bool SkipSetUp ;
    public static bool SkipSwap ;
    private bool autoFlg = false;
    private bool prebFlg = false;


    //180度系の回転 
    private bool harfRotate = false;
    private RotateDef rotating;

    //実行中のリスト
    private int indexDisp = 0;
    private int indexExcute = -1;
    private int indexSolList = 0;
    //private int indexPreb = -1;

    //下に表示する文字列
    private List<Text> dispTexts = new List<Text>();

    //完成済か
    private bool isComp = false;
    //旧　現在未使用
    //Soltype st = Soltype.set;
    private enum Soltype
    {
        set,
        swap,
        reset,
        comp
    }

    //各ひらがなのコンテナ
    private List<AContainer> SolList = new List<AContainer>();

    private aiueo aiu;
    

    void Start()
    {
        //Debug.LogWarning($"1{SkipSetUp}:{SkipSwap}");
        Initialization(false);
    }

    public void Initialization(bool set)
    {
        //テストセット。
        if (set) {
            //Debug.Log("Excute Test");
            StaticCubeInfo.TestSet();
        }
        yesno.SetActive(false);
        

        //Solveより取得する解法のリスト、インデックス
        List<int> EdgeSolution = StaticCubeInfo.s.GetEdgeSolution();
        List<int> CornerSolution = StaticCubeInfo.s.GetCornerSolution();

        sc.CreateSolutionText();
        //Debug.LogWarning($"{SkipSetUp}:{SkipSwap}");

        //Debug.Log($"解法 Edge{EdgeSolution.Count} Coeber{CornerSolution.Count}");
        foreach (int i in EdgeSolution) SolList.Add(new AContainer(i, SkipSetUp, SkipSwap));
        foreach (int i in CornerSolution) SolList.Add(new AContainer(i, SkipSetUp, SkipSwap));

        if (SolList.Count > 0)
        {
            SetDispList(SolList[0].Disp);
            //Debug.Log($"文字の長さ{SolList.Count} 現在:{indexSolList}");
        }
        else {
            isComp = true;
        }
    }

    //void DispList(List<RotateDef> rdl) {
    //    //Debug.Log("長さ:"+rdl.Count);
    //    //foreach (RotateDef rd in rdl) Debug.Log(rd);
    //}

    void Update()
    {
        if (yesno.activeSelf) return;
        if (autoFlg)DispNext();

        //回転中 or 完成済み or indexExcuteが-1
        if (harfRotate == true && ts.rottime == false)
        {
            ExcuteTriger(rotating);
        }
        else if (ts.rottime == true || isComp || indexExcute < 0)
        {
            return;
        }
        //ハーフの途中

        //一手戻す途中
        else if (prebFlg == true) {
                //Debug.Log("巻き戻し"+indexExcute);
                RotateDefTranslator rdt = new RotateDefTranslator();
                ExcuteTriger(rdt.RotateDefToReverse(SolList[indexSolList].Excute[indexDisp][indexExcute]));
                indexExcute--;
            if (indexExcute == -1) {
                //Debug.Log("巻き戻し終了" + indexExcute);
                prebFlg = false;
                //if (indexSolList == 0 && indexDisp == 0) {
                //    //巻き戻した時にそれが最初の文字だったら上の色を
                //    Debug.Log("上色変更"+indexDisp);
                //    sc.ChangeSolCharColor(indexDisp, SolList[indexSolList].IsEdge);
                //}
                //Debug.Log("下色変更");
                //changeDispListColor(indexDisp);
            }
            
        }
        //Nextリスト未消化
        else if (indexExcute != SolList[indexSolList].Excute[indexDisp].Count) {
            //Debug.Log($"ExcuteList消化 {SolList[indexSolList].Disp.Count}:{indexDisp}   {indexExcute}:{SolList[indexSolList].Excute[indexDisp].Count}");
            ExcuteTriger(SolList[indexSolList].Excute[indexDisp][indexExcute]);
            indexExcute++;

        }
        
    }


    public void DispNext()
    {
        if (isComp && autoFlg == false)
        {
            YesNo();
        }
        else if (isComp)
        {
            //Debug.Log("完成しました。");
            return;
        }
        //exucteIndexが初期値
        else if (indexExcute < 0)
        {
            
            indexExcute = 0;
            //Debug.Log($"indexExucuteがマイナス {indexSolList}:{SolList.Count}");

            if (indexDisp == 0)sc.ChangeSolCharColor(indexSolList,SolList[indexSolList].IsEdge);
            //Debug.Log($"i:{indexDisp}");
            changeDispListColor(indexDisp);
            //Debug.Log("ok");
            return;
        }
        //回転中 or ハーフの途中 or リスト未消化(indexexcute<上限)
        else if (ts.rottime == true ||  harfRotate==true || indexExcute != SolList[indexSolList].Excute[indexDisp].Count )
        {
            //Debug.Log($"回転{ts.rottime} 完成状態:{st} iExcute{indexExcute}:{SolList[indexSolList].Excute[indexDisp].Count}");
            return;
        }
        //excuteが消化済
        else if (indexExcute == SolList[indexSolList].Excute[indexDisp].Count)
        {
            indexExcute = 0;
            //Debug.Log($"indexExucuteが消化済");

            //1 dispが残っている
            //2 SolListが残っている
            //3 どちらも終了(=6面完成)

            //1 下の文字(disp)が残っている　下の文字を進める
            if (indexDisp + 1 < SolList[indexSolList].Disp.Count)
            {
                //Debug.Log($"dispを進める");                
                indexDisp++;
                changeDispListColor(indexDisp);
            }
            //2 SolListが残っている 上の文字を進める+下のリスト更新
            else if (indexSolList + 1 < SolList.Count)
            {
                //Debug.Log($"上の文字を進める");
                indexSolList++;
                indexDisp = 0;
                sc.ChangeSolCharColor(indexSolList, SolList[indexSolList].IsEdge);
                SetDispList(SolList[indexSolList].Disp);
                changeDispListColor(indexDisp);
            }
            //3 DispとSollistが終了(完成)
            else {
                //Debug.Log($"完成");
                indexExcute = SolList[indexSolList].Excute[indexDisp].Count;
                isComp = true;
            }
        }
        //Debug.Log($" 文字:{indexSolList} DIsp{indexDisp} Excute{indexExcute}");
    }

    public void Auto() {
        autoFlg = AutoToggle.isOn;
        //if (autoFlg == true)  = false;
        //else autoFlg = true;
    }

    public void Preb()
    {
        //回転中  or リスト未消化(indexexcute<上限) or オート実行中
        if (ts.rottime == true  || (0 <=indexExcute && indexExcute <SolList[indexSolList].Excute[indexDisp].Count) || autoFlg || prebFlg)
        {
            //Debug.Log($"Preb出来ない。i:{indexExcute} max:{SolList[indexSolList].Excute[indexDisp].Count}");
            return;
        }
        //excuteが消化済
        else if (ts.rottime == false ||  indexExcute == SolList[indexSolList].Excute[indexDisp].Count)
        {
            //ある回転手順の開始位置から戻す
            
            if (indexExcute == -1) {
                
                if (indexDisp - 1 >= 0)
                {
                    //dispが戻せる
                    prebFlg = true;
                    //Debug.Log("Preb 2");
                    if (indexDisp-1==0)sc.ChangeSolCharColor(indexSolList,SolList[indexSolList].IsEdge,false);
                    indexDisp--;
                    changeDispListColor(indexDisp);
                    indexExcute = SolList[indexSolList].Excute[indexDisp].Count - 1;
                    
                }
                else if (indexSolList - 1 >= 0)
                {
                    //indexSollistが戻せる
                    prebFlg = true;
                    //Debug.Log("Preb 3　上の色戻す");
                    SetDispList(SolList[indexSolList].Disp, true);
                    indexSolList--;
                    indexDisp = SolList[indexSolList].Disp.Count-1;
                    //changeDispListColor(indexDisp);
                    indexExcute = SolList[indexSolList].Excute[indexDisp].Count-1;
                    
                    isComp = false;

                    //Debug.Log($"iD{indexDisp}:{SolList[indexSolList].Disp.Count} iE{indexExcute}:{SolList[indexSolList].Excute[indexDisp].Count}");
                }//else Debug.Log("Preb 4");
            }
            else
            {
                //あるdisp文字が終了した直後
                //Debug.Log("Preb 1");
                changeDispListColor(indexDisp);
                indexExcute--;
                prebFlg = true;
                isComp = false;
                if(indexDisp==0)sc.ChangeSolCharColor(indexSolList, SolList[indexSolList].IsEdge,false);

            }
            
            
        }
    }

    //下の文字の色変更
    private void changeDispListColor(int index) {
        //Debug.Log("下色変更:"+index);
        //solcharfactoryとの共通化の必要あり。
        if (dispTexts.Count > index)
        {
            if (dispTexts[index].color == Color.black) dispTexts[index].color = Color.red;
            else dispTexts[index].color = Color.black;
        }
    }

    //下の文字列変更
    private void SetDispList(List<RotateDef> lrd , bool allred=false)
    {
        //Debug.Log("SetDispList 下の文字列セット");
        //DispList(lrd);
        GameObject obj = (GameObject)Resources.Load("chars/DispChar");
        RotateDefTranslator rdt = new RotateDefTranslator();
        GameObject[] clones = GameObject.FindGameObjectsWithTag("dispchar");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        dispTexts.Clear();
        int index = 0;
        foreach (RotateDef rd in lrd)
        {
            string s = rdt.RotateDefToString(rd);
            GameObject UIText = (GameObject)Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, DisplayList);
            Text text = UIText.GetComponent<Text>();
            text.text = s;
            dispTexts.Add(text);
            if (allred == true)
            {
                changeDispListColor(index);
            }
            index++;
        }
        //Debug.Log("下の文字列の長さ:"+dispTexts.Count);
    }

    
    public void YesNo() {
        if (yesno.activeSelf) {
            yesno.SetActive(false);
        }else yesno.SetActive(true);
    }

    public void MoveToMenu() {
        SceneManager.LoadScene("selectmenu");
    }


    private void ExcuteTriger(RotateDef rd)
    {
        //Debug.Log(rd);
        if (harfRotate == true) harfRotate = false;
        switch (rd)
        {
            case RotateDef.U:
                {
                    ts.WplusY();
                    break;
                }
            case RotateDef.PU:
                {
                    ts.WminusY();
                    break;
                }
            case RotateDef.U2:
                {
                    ts.WplusY();
                    harfRotate = true;
                    rotating = RotateDef.U;
                    break;
                }

            case RotateDef.D:
                {
                    ts.YminusY();
                    break;
                }
            case RotateDef.PD:
                {
                    ts.YplusY();
                    break;
                }
            case RotateDef.D2:
                {
                    ts.YminusY();
                    harfRotate = true;
                    rotating = RotateDef.D;
                    break;
                }
            case RotateDef.R:
                {
                    ts.RplusX();
                    break;
                }
            case RotateDef.PR:
                {
                    ts.RminusX();
                    break;
                }
            case RotateDef.R2:
                {
                    ts.RplusX();
                    harfRotate = true;
                    rotating = RotateDef.R;
                    break;
                }

            case RotateDef.L:
                {

                    ts.OminusX();
                    break;
                }
            case RotateDef.PL:
                {
                    ts.OplusX();
                    break;
                }
            case RotateDef.L2:
                {
                    ts.OminusX();
                    harfRotate = true;
                    rotating = RotateDef.L;
                    break;
                }

            case RotateDef.F:
                {
                    ts.GminusZ();
                    break;
                }
            case RotateDef.PF:
                {
                    ts.GplusZ();
                    break;
                }
            case RotateDef.F2:
                {
                    ts.GminusZ();
                    harfRotate = true;
                    rotating = RotateDef.F;
                    break;
                }

            case RotateDef.B:
                {
                    ts.BplusZ();
                    break;
                }
            case RotateDef.PB:
                {
                    ts.BminusZ();
                    break;
                }
            case RotateDef.B2:
                {
                    ts.BplusZ();
                    harfRotate = true;
                    rotating = RotateDef.B;
                    break;
                }

            case RotateDef.M:
                {
                    ts.CminusX();
                    break;
                }
            case RotateDef.PM:
                {
                    ts.CplusX();
                    break;
                }
            case RotateDef.M2:
                {
                    ts.CminusX();
                    harfRotate = true;
                    rotating = RotateDef.M;
                    break;
                }
            case RotateDef.E:
                {
                    ts.CminusY();
                    break;
                }
            case RotateDef.PE:
                {
                    ts.CplusY();
                    break;
                }
            case RotateDef.E2:
                {
                    ts.CminusY();
                    harfRotate = true;
                    rotating = RotateDef.E;
                    break;
                }

            case RotateDef.S:
                {
                    ts.CminusZ();
                    break;
                }
            case RotateDef.PS:
                {
                    ts.CplusZ();
                    break;
                }
            case RotateDef.S2:
                {
                    ts.CminusZ();
                    harfRotate = true;
                    rotating = RotateDef.S;
                    break;
                }
        }
    }

}
