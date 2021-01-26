using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AContainer 
{
    public List<List<RotateDef>> Excute = new List<List<RotateDef>>();
    public List<RotateDef> Disp = new List<RotateDef>();


    public bool IsEdge = false;

    public AContainer(int id, bool SkipSetup, bool SkipSwap) {
        List<RotateDef> setup = CubeSetups.SetUpList[id];
        List<RotateDef> rsetup = CubeSetups.RSetUpList[id];
        List<RotateDef> swap;

        List<List<RotateDef>> SetupExcute = new List<List<RotateDef>>();
        List<RotateDef> SetupDisp = new List<RotateDef>();

        List<List<RotateDef>> SwapExcute = new List<List<RotateDef>>();
        List<RotateDef> SwapDisp = new List<RotateDef>();

        List<List<RotateDef>> RSetupExcute = new List<List<RotateDef>>();
        List<RotateDef> RSetupDisp = new List<RotateDef>();

        //Debug.LogWarning($"中身{SkipSetup}:{SkipSwap}");

        if (id % 2 == 1)
        {
            swap = getSwapEdge();
            IsEdge = true;
        }
        else
        {
            swap = getSwapCorner();
        }


        if (SkipSetup == true)
        {
            SetupExcute.Add(setup);
            RSetupExcute.Add(rsetup);
            SetupDisp.Add(RotateDef.Set);
            RSetupDisp.Add(RotateDef.Rset);
        }
        else
        {
            SetupDisp = setup;
            RSetupDisp = rsetup;
            foreach (RotateDef r in setup)
            {
                SetupExcute.Add(new List<RotateDef>(1){r});
            }
            foreach (RotateDef r in rsetup)
            {
                RSetupExcute.Add(new List<RotateDef>(1) { r });
            }
        }

        if (SkipSwap == true)
        {
            SwapExcute.Add(swap);
            SwapDisp.Add(RotateDef.Swap);
            //Debug.Log("ok");
        }
        else
        {
            SwapDisp = swap;
            foreach (RotateDef r in swap) {
                SwapExcute.Add(new List<RotateDef>(1) {r});
            }
            
        }

        foreach (List<RotateDef> lrd in SetupExcute)
        {
            Excute.Add(lrd);
        }

        foreach (List<RotateDef> lrd in SwapExcute)
        {
            Excute.Add(lrd);
        }

        foreach (List<RotateDef> lrd in RSetupExcute)
        {
            Excute.Add(lrd);
        }

        Disp.AddRange(SetupDisp);
        Disp.AddRange(SwapDisp);
        Disp.AddRange(RSetupDisp);


        //Debug.Log($"Setup {SetupExcute.Count} {SwapExcute.Count} {RSetupExcute.Count}");
        //Debug.Log($"長さ {Disp.Count} {Excute.Count}");
    }


    private List<RotateDef> getSwapCorner()
    {
        //コーナー
        List<RotateDef> swap = new List<RotateDef>() {
            RotateDef.R,RotateDef.PU,RotateDef.PR,RotateDef.PU,RotateDef.R,RotateDef.U,RotateDef.PR,RotateDef.PF
            ,RotateDef.R,RotateDef.U,RotateDef.PR,RotateDef.PU,RotateDef.PR,RotateDef.F,RotateDef.R
        };
        return swap;
    }

    private List<RotateDef> getSwapEdge()
    {
        //エッジ
        List<RotateDef> swap = new List<RotateDef>() {
                RotateDef.R,RotateDef.U,RotateDef.PR,RotateDef.PU,RotateDef.PR,RotateDef.F,
                RotateDef.R2,RotateDef.PU,RotateDef.PR,RotateDef.PU,RotateDef.R,RotateDef.U,RotateDef.PR,RotateDef.PF
        };
        return swap;
    }
}
