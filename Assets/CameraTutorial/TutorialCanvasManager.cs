using System.Collections;
using System.Collections.Generic;
using OpenCvSharp;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas MainCanvas = null;
    [SerializeField] private Canvas FixCanvas = null;
    [SerializeField] private Canvas LastCanvas = null;
    [SerializeField] private GameObject Menu = null;
    [SerializeField] private Image SelectButton = null;

    [SerializeField]
    private GameObject _cube = null;

    GameObject objectCT;
    CameraTutorial CT;

    public void SelectFix()
    {
        MainCanvas.enabled = false;
        FixCanvas.enabled = true;
        Menu.SetActive(false);
    }
    public void BackMain()
    {
        LastCanvas.enabled = true;
        FixCanvas.enabled = false;
        Menu.SetActive(false);
        SelectButton.enabled = false;
    }

    public void Button0()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(-175, 210, 0);
        objectCT = GameObject.Find("CameraButton");
        CT = objectCT.GetComponent<CameraTutorial>();
        CT.FixText = 1;
    }
    public void Button1()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(0, 210, 0);
    }
    public void Button2()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(175, 210, 0);
    }
    public void Button3()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(-175, 40, 0);
    }
    public void Button4()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(0, 40, 0);
    }
    public void Button5()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(175, 40, 0);
    }
    public void Button6()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(-175, -140, 0);
    }
    public void Button7()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(0, -140, 0);
    }
    public void Button8()
    {
        SelectButton.enabled = true;
        SelectButton.transform.localPosition = new Vector3(165, -140, 0);
    }
}
