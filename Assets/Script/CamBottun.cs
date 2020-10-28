namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System;
    using System.IO;
    using System.Text;

    public class CamBottun : MonoBehaviour
    {
        public int trials = 0;
        public int Surface = 0;

        [SerializeField]
        private CubeInspection _CI = null;

        //[SerializeField]
        //private Button _button = null;

        [SerializeField]
        private Surface_Script[] _sur = null;

        [SerializeField]
        private RawImage _screen = null;
        [SerializeField]
        private Image _camImage = null;
        [SerializeField]
        private Button _camButton = null;
        [SerializeField]
        private Image _cameraframe = null;
        [SerializeField]
        private RawImage _cubemodel = null;
        [SerializeField]
        private Button _yes = null;
        [SerializeField]
        private Text _yestext = null;
        [SerializeField]
        private Button _no = null;
        [SerializeField]
        private Text _notext = null;
        [SerializeField]
        private GameObject _cube = null;

        private int colornum;

        //new
        [SerializeField]
        private GameObject _pin = null;
        public void CamClick()
        {
            string image = "Assets/ScreenShot/" + trials.ToString() + "_" + Surface.ToString() + ".png";
            Debug.Log(image);
            //ScreenCapture.CaptureScreenshot(image);

            StartCoroutine(Capture(image));


        }

        IEnumerator Capture(string image)
        {
            // ①
            yield return new WaitForEndOfFrame();

            // ②
            Vector2 size = new Vector2(105.0f, 105.0f); //可変 325
            Texture2D tex = new Texture2D((int)size.x,
                            (int)size.y,
                            TextureFormat.ARGB32,
                            false);

            // ③
            for (int i = 0; i < 9; i++)
            {
                Vector2 pinPos = _pin.gameObject.transform.position;
                float x=0, y=0;
                Rect _rect = new Rect((int)x, (int)y, (int)size.x, (int)size.y);
                if (i % 3 == 0)
                {
                    x = pinPos.x;
                }
                else if (i % 3 == 1)
                {
                    x = pinPos.x+110;
                }
                else if (i % 3 == 2)
                {
                    x = pinPos.x+220;
                }

                if (i / 3 == 2)
                {
                    y = pinPos.y;
                }
                else if (i / 3 == 1)
                {
                    y = pinPos.y+110;
                }
                else if (i / 3 == 0)
                {
                    y = pinPos.y+220;
                }
                tex.ReadPixels(new UnityEngine.Rect ((int)x, (int)y, (int)size.x, (int)size.y), 0, 0);
                //可変　　可変

                // ④
                tex.Apply();

                // ⑤
                //string image_path = "SS.png";
                byte[] pngdata = tex.EncodeToPNG();
                //File.WriteAllBytes(image, pngdata);


                colornum = _CI.Inspection(Surface, i, tex);
                pasting(Surface, i, pngdata);
            }

            Surface++;

            if (Surface >= 6)
            {
                OffImage();
            }
        }

        void pasting(int _num, int i, byte[] data)
        {

            _sur[_num * 9 + i].done = true;
            //_sur[_num * 9 + i].pngData = data;
            _sur[_num * 9 + i].colorPanel(colornum);
        }

        void OffImage()
        {
            _screen.enabled = false;
            _camImage.enabled = false;
            _camButton.enabled = false;
            _cameraframe.enabled = false;
            _cubemodel.transform.localPosition = new Vector3(0, 0, 0);
            _yes.enabled = true;
            _yestext.enabled = true;
            _no.enabled = true;
            _notext.enabled = true;

            /*for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sur[i * 9 + j].mosaicEffect();
                }
            }*/

            _cube.transform.eulerAngles = new Vector3(-10, 25, 173);
        }

        public void OnImage()
        {
            _screen.enabled = true;
            _camImage.enabled = true;
            _camButton.enabled = true;
            _cameraframe.enabled = true;
            _cubemodel.transform.localPosition = new Vector3(-200, -450, 0);
            _yes.enabled = false;
            _yestext.enabled = false;
            _no.enabled = false;
            _notext.enabled = false;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sur[i * 9 + j].resetSurfaces();
                }
            }

            _cube.transform.eulerAngles = new Vector3(-10, 25, 173);

            Surface = 0;
        }
    }
}
