using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTutorial : MonoBehaviour
{
    public int Surface_num = 0;
    public int Panel_num = 0;
    public int tuto = 0;
    public int MainText = 0;
    public int FixText = 0;
    [SerializeField]
    Renderer _renderer = null;
    [SerializeField]
    private CameraTutorial[] CT = null;

    
    public void NextText()
    {
        MainText++;
    }

    public void NextTextF()
    {
        FixText++;
    }


    public void TCButton()
    {
        if (tuto == 0)
        {
            MainText = 2;
        }else if (tuto == 1)
        {
            MainText = 4;
        }

        for (int i = 0; i < 9; i++)
        {
            CT[i].TutorialCamClick();
        }
        
    }

    public void TRButton()
    {
        if (tuto == 0)
        {
            MainText = 3;
        }
        for (int i = 0; i < 9; i++)
        {
            CT[i].TutorialRetakeClick();
        }
        tuto = 1;
        

    }

    public void TutorialCamClick()
    {
        
        if (tuto == 0)
        {
            if (Panel_num == 4 || Panel_num == 6)
            {
                _renderer.materials[0].color = new Color32(243, 22, 15, 255);
            }
            if (Panel_num == 1)
            {
                _renderer.materials[0].color = new Color32(32, 183, 8, 255);
            }
            if (Panel_num == 0 || Panel_num == 2 || Panel_num == 3)
            {
                _renderer.materials[0].color = new Color32(243, 22, 15, 255);
            }
            if (Panel_num == 7 || Panel_num == 8)
            {
                _renderer.materials[0].color = new Color32(253, 244, 18, 255);
            }
            if (Panel_num == 5)
            {
                _renderer.materials[0].color = new Color32(229, 149, 27, 255);
            }
        }
        else if (tuto == 1)
        {
            if (Panel_num == 0 || Panel_num == 4 || Panel_num == 6)
            {
                _renderer.materials[0].color = new Color32(32, 183, 8, 255);
            }
            if (Panel_num == 1)
            {
                _renderer.materials[0].color = new Color32(243, 22, 15, 255);
            }
            if (Panel_num == 2 || Panel_num == 3)
            {
                _renderer.materials[0].color = new Color32(29, 100, 248, 255);
            }
            if (Panel_num == 7 || Panel_num == 8)
            {
                _renderer.materials[0].color = new Color32(229, 149, 27, 255);
            }
            if (Panel_num == 5)
            {
                _renderer.materials[0].color = new Color32(253, 244, 18, 255);
            }
        }

    }

    public void TutorialRetakeClick()
    {
        _renderer.materials[0].color = new Color32(253, 0, 0, 255);
        tuto = 1;

    }

    public void TCCButton()
    {
        CT[0].TChangeBule();
        FixText = 2;
    }

    public void TChangeBule()
    {
        _renderer.materials[0].color = new Color32(29, 100, 248, 255);
        FixText = 2;
    }
}
