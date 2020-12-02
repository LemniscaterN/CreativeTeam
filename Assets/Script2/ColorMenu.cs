namespace OpenCvSharp
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ColorMenu : MonoBehaviour
    {
        [SerializeField] private GameObject Menu = null;
        //public int Button0 = 0;
        [SerializeField] private ChangeColor cc = null;


        public void OpenMenu(int Button0)
        {
            cc.panel_num = Button0;
            Menu.SetActive(true);
        }

        public void CloseMenu()
        {
            Menu.SetActive(false);
        }


    }
}
