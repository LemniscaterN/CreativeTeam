namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class PanelText : MonoBehaviour
    {
        private Text targetText;
        [SerializeField]
        private Text _text = null;
        [SerializeField]
        CanvasManager cm = null;

        void Update()
        {
            if (cm.menusurface == 0)
            {
                FirstText();
            }
            else if (cm.menusurface == 1)
            {
                SecondText();
            }
            else if (cm.menusurface == 2)
            {
                ThirdText();
            }
            else if (cm.menusurface == 3)
            {
                FourthText();
            }
            else if (cm.menusurface == 4)
            {
                FifthText();
            }
            else if (cm.menusurface == 5)
            {
                LastText();
            }
        }

        public void FirstText()
        {
            this.targetText = _text;
            this.targetText.text = "一面目";
        }

        public void SecondText()
        {
            this.targetText = _text;
            this.targetText.text = "二面目";
        }

        public void ThirdText()
        {
            this.targetText = _text;
            this.targetText.text = "三面目";
        }

        public void FourthText()
        {
            this.targetText = _text;
            this.targetText.text = "四面目";
        }

        public void FifthText()
        {
            this.targetText = _text;
            this.targetText.text = "五面目";
        }

        public void LastText()
        {
            this.targetText = _text;
            this.targetText.text = "六面目";
        }
    }
}
