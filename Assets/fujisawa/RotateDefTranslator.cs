using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDefTranslator
{
    public RotateDef StringToRotateDef(string s)
    {
        RotateDef rd = RotateDef.Err;
        switch (s)
        {
            case "U":
                {
                    rd = RotateDef.U;
                    break;
                }
            case "U\'":
                {
                    rd = RotateDef.PU;
                    break;
                }
            case "U2":
                {
                    rd = RotateDef.U2;
                    break;
                }
            case "D":
                {
                    rd = RotateDef.D;
                    break;
                }
            case "D\'":
                {
                    rd = RotateDef.PD;
                    break;
                }
            case "D2":
                {
                    rd = RotateDef.D2;
                    break;
                }
            case "R":
                {
                    rd = RotateDef.R;
                    break;
                }
            case "R\'":
                {
                    rd = RotateDef.PR;
                    break;
                }
            case "R2":
                {
                    rd = RotateDef.R2;
                    break;
                }
            case "L":
                {
                    rd = RotateDef.L;
                    break;
                }
            case "L\'":
                {
                    rd = RotateDef.PL;
                    break;
                }
            case "L2":
                {
                    rd = RotateDef.L2;
                    break;
                }
            case "F":
                {
                    rd = RotateDef.F;
                    break;
                }
            case "F\'":
                {
                    rd = RotateDef.PF;
                    break;
                }
            case "F2":
                {
                    rd = RotateDef.F2;
                    break;
                }
            case "B":
                {
                    rd = RotateDef.B;
                    break;
                }
            case "B\'":
                {
                    rd = RotateDef.PB;
                    break;
                }
            case "B2":
                {
                    rd = RotateDef.B2;
                    break;
                }
            case "M":
                {
                    rd = RotateDef.M;
                    break;
                }
            case "M\'":
                {
                    rd = RotateDef.PM;
                    break;
                }
            case "M2":
                {
                    rd = RotateDef.M2;
                    break;
                }
            case "S":
                {
                    rd = RotateDef.S;
                    break;
                }
            case "S\'":
                {
                    rd = RotateDef.PS;
                    break;
                }
            case "S2":
                {
                    rd = RotateDef.S2;
                    break;
                }
            case "E":
                {
                    rd = RotateDef.E;
                    break;
                }
            case "E\'":
                {
                    rd = RotateDef.PE;
                    break;
                }
            case "E2":
                {
                    rd = RotateDef.E2;
                    break;
                }
        }
        return rd;
    }


    public string RotateDefToString(RotateDef rd)
    {
        string s = "Err";
        switch (rd)
        {
            case RotateDef.U:
                {
                    s = "U";
                    break;
                }
            case RotateDef.PU:
                {
                    s = "U\'";
                    break;
                }
            case RotateDef.U2:
                {
                    s = "U2";
                    break;
                }
            case RotateDef.D:
                {
                    s = "D";
                    break;
                }
            case RotateDef.PD:
                {
                    s = "D\'";
                    break;
                }
            case RotateDef.D2:
                {
                    s = "D2";
                    break;
                }
            case RotateDef.R:
                {
                    s = "R";
                    break;
                }
            case RotateDef.PR:
                {
                    s = "R\'";
                    break;
                }
            case RotateDef.R2:
                {
                    s = "R2";
                    break;
                }
            case RotateDef.L:
                {
                    s = "L";
                    break;
                }
            case RotateDef.PL:
                {
                    s = "L\'";
                    break;
                }
            case RotateDef.L2:
                {
                    s = "L2";
                    break;
                }
            case RotateDef.F:
                {
                    s = "F";
                    break;
                }
            case RotateDef.PF:
                {
                    s = "F\'";
                    break;
                }
            case RotateDef.F2:
                {
                    s = "F2";
                    break;
                }
            case RotateDef.B:
                {
                    s = "B";
                    break;
                }
            case RotateDef.PB:
                {
                    s = "B\'";
                    break;
                }
            case RotateDef.B2:
                {
                    s = "B2";
                    break;
                }
            case RotateDef.M:
                {
                    s = "M";
                    break;
                }
            case RotateDef.PM:
                {
                    s = "M\'";
                    break;
                }
            case RotateDef.M2:
                {
                    s = "M2";
                    break;
                }
            case RotateDef.S:
                {
                    s = "S";
                    break;
                }
            case RotateDef.PS:
                {
                    s = "S\'";
                    break;
                }
            case RotateDef.S2:
                {
                    s = "S2";
                    break;
                }
            case RotateDef.E:
                {
                    s = "E";
                    break;
                }
            case RotateDef.PE:
                {
                    s = "E\'";
                    break;
                }
            case RotateDef.E2:
                {
                    s = "E2";
                    break;
                }
            case RotateDef.Blank:
                {
                    s = "";
                    break;
                }
        }
        return s;
    }


    public RotateDef RotateDefToReverse(RotateDef rd)
    {
        RotateDef re = RotateDef.Err;
        switch (rd)
        {
            case RotateDef.U:
                {
                    re = RotateDef.PU;
                    break;
                }
            case RotateDef.PU:
                {
                    re = RotateDef.U;
                    break;
                }
            case RotateDef.U2:
                {
                    re = RotateDef.U2;
                    break;
                }
            case RotateDef.D:
                {
                    re = RotateDef.PD;
                    break;
                }
            case RotateDef.PD:
                {
                    re = RotateDef.D;
                    break;
                }
            case RotateDef.D2:
                {
                    re = RotateDef.D2;
                    break;
                }
            case RotateDef.R:
                {
                    re = RotateDef.PR;
                    break;
                }
            case RotateDef.PR:
                {
                    re = RotateDef.R;
                    break;
                }
            case RotateDef.R2:
                {
                    re = RotateDef.R2;
                    break;
                }
            case RotateDef.L:
                {
                    re = RotateDef.PL;
                    break;
                }
            case RotateDef.PL:
                {
                    re = RotateDef.L;
                    break;
                }
            case RotateDef.L2:
                {
                    re = RotateDef.L2;
                    break;
                }
            case RotateDef.F:
                {
                    re = RotateDef.PF;
                    break;
                }
            case RotateDef.PF:
                {
                    re = RotateDef.F;
                    break;
                }
            case RotateDef.F2:
                {
                    re = RotateDef.F;
                    break;
                }
            case RotateDef.B:
                {
                    re = RotateDef.PB;
                    break;
                }
            case RotateDef.PB:
                {
                    re = RotateDef.B;
                    break;
                }
            case RotateDef.B2:
                {
                    re = RotateDef.B2;
                    break;
                }
            case RotateDef.M:
                {
                    re = RotateDef.PM;
                    break;
                }
            case RotateDef.PM:
                {
                    re = RotateDef.M;
                    break;
                }
            case RotateDef.M2:
                {
                    re = RotateDef.M2;
                    break;
                }
            case RotateDef.S:
                {
                    re = RotateDef.PS;
                    break;
                }
            case RotateDef.PS:
                {
                    re = RotateDef.S;
                    break;
                }
            case RotateDef.S2:
                {
                    re = RotateDef.S2;
                    break;
                }
            case RotateDef.E:
                {
                    re = RotateDef.PE;
                    break;
                }
            case RotateDef.PE:
                {
                    re = RotateDef.E;
                    break;
                }
            case RotateDef.E2:
                {
                    re = RotateDef.E2;
                    break;
                }
            case RotateDef.Blank:
                {
                    re = RotateDef.Blank;
                    break;
                }
        }
        return re;
    }
}
