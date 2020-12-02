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
        //public GameObject Cam;
        // Start is called before the first frame update
        void Start()
        {

        }

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
            this.targetText.text = "中心が白の面を\n撮ってください"; //最初の面のテキスト(以下テキスト編集可)
        }

        public void SecondText()
        {
            this.targetText = _text;
            this.targetText.text = "二面目";  //二枚目に撮る写真のテキスト
        }

        public void ThirdText()
        {
            this.targetText = _text;
            this.targetText.text = "三面目"; //三枚目に撮る写真のテキスト
        }

        public void FourthText()
        {
            this.targetText = _text;
            this.targetText.text = "四面目"; //四枚目に撮る写真のテキスト
        }

        public void FifthText()
        {
            this.targetText = _text;
            this.targetText.text = "五面目"; //五枚目に撮る写真のテキスト
        }

        public void LastText()
        {
            this.targetText = _text;
            this.targetText.text = "六面目（最後）"; //最後に撮る写真のテキスト
        }

        public void CheckText()
        {
            this.targetText = _text;
            this.targetText.text = "これで間違いないですか？"; //最後に撮る写真のテキスト
        }
    }
}
