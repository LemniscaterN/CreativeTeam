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
        private Image yesimage = null;
        [SerializeField]
        private Text _yestext = null;
        [SerializeField]
        private Button _no = null;
        [SerializeField]
        private Image noimage = null;
        [SerializeField]
        private Text _notext = null;
        [SerializeField]
        private GameObject _cube = null;

        private int colornum;

        //new
        [SerializeField]
        private GameObject _pin = null;

        [SerializeField]
        private ChangeColor cc = null;
        [SerializeField]
        private CanvasManager cm = null;

        public void CamClick()
        {
            string image = "Assets/ScreenShot/" + trials.ToString() + "_" + Surface.ToString() + ".png";
            Debug.Log(image);
            //ScreenCapture.CaptureScreenshot(image);

            StartCoroutine(Capture(image));

            if(Surface==1) _cube.transform.eulerAngles = new Vector3(0, 90, 180);
            if(Surface==2) _cube.transform.eulerAngles = new Vector3(0, 180, 180);
            if(Surface==3) _cube.transform.eulerAngles = new Vector3(0, 270, 180);
            if(Surface==4) _cube.transform.eulerAngles = new Vector3(0, 270, 270);
            if(Surface==5) _cube.transform.eulerAngles = new Vector3(0, 270, 90);


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
                if (i % 3 == 2)
                {
                    x = pinPos.x+440;
                }
                else if (i % 3 == 1)
                {
                    x = pinPos.x+220;
                }
                else if (i % 3 == 0)
                {
                    x = pinPos.x;
                }

                if (i / 3 == 2)
                {
                    y = pinPos.y;
                }
                else if (i / 3 == 1)
                {
                    y = pinPos.y+220;
                }
                else if (i / 3 == 0)
                {
                    y = pinPos.y+440;
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

            
            cc.Surface_num = Surface;
            cm.menusurface = Surface;

            Surface++;
            if (Surface >= 6)
            {
                OffImage();
            }
        }

        void pasting(int _num, int i, byte[] data)
        {

            _sur[_num * 9 + i].done = true;
            _sur[_num * 9 + i].pngData = data;
            //_sur[_num * 9 + i].colorPanel(colornum);
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
            yesimage.enabled = true;
            _no.enabled = true;
            _notext.enabled = true;
            noimage.enabled = true;

            /*for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sur[i * 9 + j].mosaicEffect();
                }
            }*/

            _cube.transform.eulerAngles = new Vector3(0, 270, 90);
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
            yesimage.enabled = false;
            _no.enabled = false;
            _notext.enabled = false;
            noimage.enabled = false;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sur[i * 9 + j].resetSurfaces();
                }
            }

            _cube.transform.eulerAngles = new Vector3(0, 0, 180);

            Surface = 0;
        }

        public void ChangeColor(int i, int j,color col)
        {

            _sur[i * 9 + j].colorPanel((int)col);

        }

        public void Retake()
        {
            if (Surface > 0)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sur[(Surface - 1) * 9 + j].resetSurfaces();
                }
                Surface--;
            }

            if (Surface == 0) _cube.transform.eulerAngles = new Vector3(0, 0, 180);
            if (Surface == 1) _cube.transform.eulerAngles = new Vector3(0, 90, 180);
            if (Surface == 2) _cube.transform.eulerAngles = new Vector3(0, 180, 180);
            if (Surface == 3) _cube.transform.eulerAngles = new Vector3(0, 270, 180);
            if (Surface == 4) _cube.transform.eulerAngles = new Vector3(0, 270, 270);
            if (Surface == 5)
            {
                _screen.enabled = true;
                _camImage.enabled = true;
                _camButton.enabled = true;
                _cameraframe.enabled = true;
                _cubemodel.transform.localPosition = new Vector3(-200, -450, 0);
                _yes.enabled = false;
                _yestext.enabled = false;
                yesimage.enabled = false;
                _no.enabled = false;
                _notext.enabled = false;
                noimage.enabled = false;
                _cube.transform.eulerAngles = new Vector3(0, 270, 90);
            }
        }
    }
}
