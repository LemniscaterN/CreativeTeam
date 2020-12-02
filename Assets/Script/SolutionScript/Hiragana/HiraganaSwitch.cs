using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiraganaSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject hiragana = null;

    bool hiraSwitch = true;

    public void HiraganaOnOff()
    {
        hiraSwitch = !hiraSwitch;
        hiragana.SetActive(hiraSwitch);
    }
}
