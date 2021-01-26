using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiraganaSwitch : MonoBehaviour
{
    enum HiraSwitch{
        none,
        all,
        edge,
        corner,
    }
    [SerializeField]
    private GameObject hiraganaEdge = null;
    [SerializeField]
    private GameObject hiraganaCorner = null;
    [SerializeField]
    private Text text = null;

    HiraSwitch hiraswitch = HiraSwitch.none;

    public void HiraganaOnOff()
    {
        if (hiraswitch == HiraSwitch.none)
        {
            hiraswitch = HiraSwitch.edge;
            hiraganaEdge.SetActive(false);
        }else if (hiraswitch == HiraSwitch.edge)
        {
            hiraswitch = HiraSwitch.corner;
            hiraganaCorner.SetActive(false);
            hiraganaEdge.SetActive(true);
        }
        else if (hiraswitch == HiraSwitch.corner)
        {
            hiraswitch = HiraSwitch.all;
            hiraganaEdge.SetActive(false);
        }
        else if (hiraswitch == HiraSwitch.all)
        {
            hiraswitch = HiraSwitch.none;
            hiraganaCorner.SetActive(true);
            hiraganaEdge.SetActive(true);
        }
    }
}
