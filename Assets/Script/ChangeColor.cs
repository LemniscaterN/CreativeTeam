namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class ChangeColor : MonoBehaviour
    {
        public int Surface_num = 0;
        public int panel_num = 0;
        //[SerializeField] Renderer _renderer = null;
        [SerializeField]
        CamBottun _cam = null;

        public void ChangeGreen()
        {
            _cam.ChangeColor(Surface_num, panel_num, 0);
            //_renderer.materials[0].color = new Color32(32, 183, 8, 255);
        }

        public void ChangeRed()
        {
            _cam.ChangeColor(Surface_num, panel_num, color.red);
        }

        public void ChangeBlue()
        {
            _cam.ChangeColor(Surface_num, panel_num, color.blue);
        }

        public void ChangeOrange()
        {
            _cam.ChangeColor(Surface_num, panel_num, color.orange);
        }

        public void ChangeWhite()
        {
            _cam.ChangeColor(Surface_num, panel_num, color.white);
        }

        public void ChangeYellow()
        {
            _cam.ChangeColor(Surface_num, panel_num, color.yellow);
        }
    }
}