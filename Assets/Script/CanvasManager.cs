namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Canvas MainCanvas = null;
        [SerializeField] private Canvas FixCanvas = null;
        [SerializeField] private GameObject Menu = null;
        [SerializeField] private Image SelectButton = null;

        [SerializeField]
        CamBottun _cam = null;
        [SerializeField]
        private GameObject _cube = null;

        [SerializeField]
        private ChangeColor cc = null;

        public int menusurface = 0;


        public void SelectFix()
        {
            MainCanvas.enabled = false;
            FixCanvas.enabled = true;
            Menu.SetActive(false);
        }

        public void BackMain()
        {
            MainCanvas.enabled = true;
            FixCanvas.enabled = false;
            Menu.SetActive(false);
            SelectButton.enabled = false;
        }

        public void NextPanel()
        {

            menusurface++;
            

            if (menusurface > 5) menusurface = 0;
            cc.Surface_num = menusurface;
            Debug.Log(menusurface);
            if (menusurface == 0) _cube.transform.eulerAngles = new Vector3(0, 0, 180);
            if (menusurface == 1) _cube.transform.eulerAngles = new Vector3(0, 90, 180);
            if (menusurface == 2) _cube.transform.eulerAngles = new Vector3(0, 180, 180);
            if (menusurface == 3) _cube.transform.eulerAngles = new Vector3(0, 270, 180);
            if (menusurface == 4) _cube.transform.eulerAngles = new Vector3(0, 270, 270);
            if (menusurface == 5) _cube.transform.eulerAngles = new Vector3(0, 270, 90);
            

        }

        public void PreviousPanel()
        {
            menusurface--;
            

            if (menusurface < 0) menusurface = 5;
            cc.Surface_num = menusurface;
            Debug.Log(menusurface);
            if (menusurface == 0) _cube.transform.eulerAngles = new Vector3(0, 0, 180);
            if (menusurface == 1) _cube.transform.eulerAngles = new Vector3(0, 90, 180);
            if (menusurface == 2) _cube.transform.eulerAngles = new Vector3(0, 180, 180);
            if (menusurface == 3) _cube.transform.eulerAngles = new Vector3(0, 270, 180);
            if (menusurface == 4) _cube.transform.eulerAngles = new Vector3(0, 270, 270);
            if (menusurface == 5) _cube.transform.eulerAngles = new Vector3(0, 270, 90);
            

        }

        public void Button0()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(-175, 360, 0);
        }
        public void Button1()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(0, 360, 0);
        }
        public void Button2()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(175, 360, 0);
        }
        public void Button3()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(-175, 190, 0);
        }
        public void Button4()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(0, 190, 0);
        }
        public void Button5()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(175, 190, 0);
        }
        public void Button6()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(-175, 10, 0);
        }
        public void Button7()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(0, 10, 0);
        }
        public void Button8()
        {
            SelectButton.enabled = true;
            SelectButton.transform.localPosition = new Vector3(165, 10, 0);
        }




    }
}
