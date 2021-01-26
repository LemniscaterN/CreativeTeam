namespace OpenCvSharp
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Instruction_script : MonoBehaviour
    {
        private Text targetText;
        [SerializeField]
        private Text _text = null;
        [SerializeField]
        CamBottun _cam = null;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_cam.Surface == 0)
            {
                FirstText();
            }
            else if (_cam.Surface == 1)
            {
                SecondText();
            }
            else if (_cam.Surface == 2)
            {
                ThirdText();
            }
            else if (_cam.Surface == 3)
            {
                FourthText();
            }
            else if (_cam.Surface == 4)
            {
                FifthText();
            }
            else if (_cam.Surface == 5)
            {
                LastText();
            }
            else if (_cam.Surface == 6)
            {
                CheckText();
            }
        }

        public void FirstText()
        {
            this.targetText = _text;
            this.targetText.text = "中心が白の面を上に向けて、中心が緑の面を撮影"; //最初の面のテキスト(以下テキスト編集可)
        }

        public void SecondText()
        {
            this.targetText = _text;
            this.targetText.text = "右に回して、中心が赤の面を撮影";  //二枚目に撮る写真のテキスト
        }

        public void ThirdText()
        {
            this.targetText = _text;
            this.targetText.text = "右に回して、中心が青の面を撮影"; //三枚目に撮る写真のテキスト
        }

        public void FourthText()
        {
            this.targetText = _text;
            this.targetText.text = "右に回して、中心がオレンジの面を撮影"; //四枚目に撮る写真のテキスト
        }

        public void FifthText()
        {
            this.targetText = _text;
            this.targetText.text = "上の面を手前に回して、中心が白の面を撮影"; //五枚目に撮る写真のテキスト
        }

        public void LastText()
        {
            this.targetText = _text;
            this.targetText.text = "上の面を2回手前に回して中心が黄色の面を撮影"; //最後に撮る写真のテキスト
        }

        public void CheckText()
        {
            this.targetText = _text;
            this.targetText.text = "これで間違いないですか？"; //最後に撮る写真のテキスト
        }
    }
}
