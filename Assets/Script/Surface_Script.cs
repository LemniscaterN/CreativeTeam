namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;
    using UnityEngine;
    using System.IO;
    using UnityEngine.UI;

    public class Surface_Script : MonoBehaviour
    {
        public CamBottun Cam;
        public int Surface_num = 0;
        public int panel_num = 0;
        public bool done = false;
        Color color;
        Color _cap;
        [SerializeField]
        Renderer _renderer = null;

        public byte[] pngData;

        private int thisColor = 0;

        // Update is called once per frame
        void Update()
        {
            thisColor = (int)CubeInspection.colorArray[Surface_num, panel_num];
            if (done == false)
            {
                color = new Color32(255, 0, 0, 255);
                if (Cam == true)
                {
                    if (Cam.Surface == Surface_num)
                    {
                        //Debug.Log("aaa" + Surface_num);
                        float sin = Mathf.Sin(Time.time * 2);

                        color.a = Mathf.Abs(sin);

                        _renderer.materials[0].color = color;
                    }
                    else
                    {
                        color.a = 0.0f;
                        _renderer.materials[0].color = color;
                    }
                }
            }
            else if (done == true)
            {
                
                if (thisColor == 0)
                {
                    _renderer.materials[0].color = new Color32(32, 183, 8, 255);
                }
                else if (thisColor == 1)
                {
                    _renderer.materials[0].color = new Color32(243, 22, 15, 255);
                }
                else if (thisColor == 2)
                {
                    _renderer.materials[0].color = new Color32(29, 100, 248, 255);
                }
                else if (thisColor == 3)
                {
                    _renderer.materials[0].color = new Color32(229, 149, 27, 255);
                }
                else if (thisColor == 4)
                {
                    _renderer.materials[0].color = new Color32(255, 255, 255, 255);
                }
                else if (thisColor == 5)
                {
                    _renderer.materials[0].color = new Color32(253, 244, 18, 255);
                }

                /*
                color = _renderer.materials[0].color;
                _cap = _renderer.materials[1].color;
                //byte[] image = File.ReadAllBytes("Assets/ScreenShot/0_"+Surface_num.ToString()+".png");
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(pngData);
                _renderer.materials[1].SetTexture("_MainTex", texture);

                color.a = 0.0f;
                _renderer.materials[0].color = color;
                _cap.a = 255f;
                _renderer.materials[1].color = _cap;
                */
                
            }

        }

        public void resetSurfaces()
        {
            done = false;
            _cap = _renderer.materials[1].color;
            _cap.a = 0.0f;
            _renderer.materials[1].color = _cap;
        }

        /*public void mosaicEffect()
        {
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(pngData);

            color_num = Surface_num;

        }*/

        public void colorPanel(int colorNum)
        {
            thisColor = colorNum;
            CubeInspection.colorArray[Surface_num, panel_num] = (color)colorNum;
        }
    }
}
