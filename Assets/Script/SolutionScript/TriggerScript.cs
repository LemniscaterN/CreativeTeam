using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public enum ROTATION
    {
        Xaxis,
        Yaxis,
        Zaxis,
    }
    //[SerializeField]
    //private GameObject Body = null;
    [SerializeField]
    private CubesPosition[] cubes = null;

    private CubesPosition[,,] posNum = new CubesPosition[3, 3, 3];

    [SerializeField]
    private GameObject axis = null;

    public bool rottime = false; //falseの時回転可能

    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                for(int k = 0; k < 3; k++)
                {
                    posNum[i, j, k] = cubes[i*9 + j*3 + k];
                    cubes[i*9 + j*3 + k].SetPosition(i, j, k);
                }
            }
        }
    }

    private void Update()
    {
        if (rottime == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GplusZ();
            }

            else if (Input.GetKeyDown(KeyCode.W))
            {
                GminusZ();
            }

            else if (Input.GetKeyDown(KeyCode.E))
            {
                RminusX();
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                RplusX();
            }

            else if (Input.GetKeyDown(KeyCode.T))
            {
                BminusZ();
            }

            else if (Input.GetKeyDown(KeyCode.Y))
            {
                BplusZ();
            }

            else if (Input.GetKeyDown(KeyCode.U))
            {
                OplusX();
            }

            else if (Input.GetKeyDown(KeyCode.I))
            {
                OminusX();
            }

            else if (Input.GetKeyDown(KeyCode.O))
            {
                WminusY();
            }

            else if (Input.GetKeyDown(KeyCode.P))
            {
                WplusY();
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                YplusY();
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                YminusY();
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                CplusX();
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                CminusX();
            }

            else if (Input.GetKeyDown(KeyCode.G))
            {
                CplusY();
            }

            else if (Input.GetKeyDown(KeyCode.H))
            {
                CminusY();
            }

            else if (Input.GetKeyDown(KeyCode.J))
            {
                CplusZ();
            }

            else if (Input.GetKeyDown(KeyCode.K))
            {
                CminusZ();
            }
        }
    }

    IEnumerator RotateAnimation(CubesPosition[] rotCubes,Vector3 vec)
    {
        rottime = true;
        for(int k = 0; k < 9; k++)
        {
            rotCubes[k].Switch();
            rotCubes[k].gameObject.transform.parent = axis.transform;
        }

        for (int j = 0; j < 45; j++)
        {
            yield return new WaitForSeconds(0.01f);
            Quaternion rot = Quaternion.AngleAxis(2, vec);
            Quaternion q = axis.transform.rotation;
            axis.transform.rotation = q * rot;
        }

        for (int l = 0; l < 9; l++)
        {
            rotCubes[l].Switch();
            rotCubes[l].gameObject.transform.parent = this.gameObject.transform;
        }
        axis.transform.localEulerAngles = new Vector3(0, 0, 0);
        
        rottime = false;
    }

    

    //緑の面を左に回す
    public void GplusZ()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for(int j = 0; j < 3; j++)
        {
            for(int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[0, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes,Vector3.forward));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 0, 2];
        changePos[0, 1] = posNum[0, 1, 2];
        changePos[0, 2] = posNum[0, 2, 2];
        changePos[1, 0] = posNum[0, 0, 1];
        changePos[1, 1] = posNum[0, 1, 1];
        changePos[1, 2] = posNum[0, 2, 1];
        changePos[2, 0] = posNum[0, 0, 0];
        changePos[2, 1] = posNum[0, 1, 0];
        changePos[2, 2] = posNum[0, 2, 0];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[0, j, k] = changePos[j, k];
                posNum[0, j, k].SetPosition(0, j, k);
            }
        }
    }
    //緑の面を右に回す
    public void GminusZ()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[0, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.back));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 2, 0];
        changePos[0, 1] = posNum[0, 1, 0];
        changePos[0, 2] = posNum[0, 0, 0];
        changePos[1, 0] = posNum[0, 2, 1];
        changePos[1, 1] = posNum[0, 1, 1];
        changePos[1, 2] = posNum[0, 0, 1];
        changePos[2, 0] = posNum[0, 2, 2];
        changePos[2, 1] = posNum[0, 1, 2];
        changePos[2, 2] = posNum[0, 0, 2];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[0, j, k] = changePos[j, k];
                posNum[0, j, k].SetPosition(0, j, k);
            }
        }
    }
    //赤の面を左に回す
    public void RminusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 2];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.left));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 0, 2];
        changePos[0, 1] = posNum[1, 0, 2];
        changePos[0, 2] = posNum[0, 0, 2];
        changePos[1, 0] = posNum[2, 1, 2];
        changePos[1, 1] = posNum[1, 1, 2];
        changePos[1, 2] = posNum[0, 1, 2];
        changePos[2, 0] = posNum[2, 2, 2];
        changePos[2, 1] = posNum[1, 2, 2];
        changePos[2, 2] = posNum[0, 2, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 2] = changePos[i, j];
                posNum[i, j, 2].SetPosition(i, j, 2);
            }
        }
    }
    //赤の面を右に回す
    public void RplusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 2];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.right));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 2, 2];
        changePos[0, 1] = posNum[1, 2, 2];
        changePos[0, 2] = posNum[2, 2, 2];
        changePos[1, 0] = posNum[0, 1, 2];
        changePos[1, 1] = posNum[1, 1, 2];
        changePos[1, 2] = posNum[2, 1, 2];
        changePos[2, 0] = posNum[0, 0, 2];
        changePos[2, 1] = posNum[1, 0, 2];
        changePos[2, 2] = posNum[2, 0, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 2] = changePos[i, j];
                posNum[i, j, 2].SetPosition(i, j, 2);
            }
        }
    }
    //青の面を左に回す
    public void BminusZ()
    {
        Debug.Log("aa");
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[2, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.back));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 2, 0];
        changePos[0, 1] = posNum[2, 1, 0];
        changePos[0, 2] = posNum[2, 0, 0];
        changePos[1, 0] = posNum[2, 2, 1];
        changePos[1, 1] = posNum[2, 1, 1];
        changePos[1, 2] = posNum[2, 0, 1];
        changePos[2, 0] = posNum[2, 2, 2];
        changePos[2, 1] = posNum[2, 1, 2];
        changePos[2, 2] = posNum[2, 0, 2];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[2, j, k] = changePos[j, k];
                posNum[2, j, k].SetPosition(2, j, k);
            }
        }
    }
    //青の面を右に回す
    public void BplusZ()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[2, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.forward));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 0, 2];
        changePos[0, 1] = posNum[2, 1, 2];
        changePos[0, 2] = posNum[2, 2, 2];
        changePos[1, 0] = posNum[2, 0, 1];
        changePos[1, 1] = posNum[2, 1, 1];
        changePos[1, 2] = posNum[2, 2, 1];
        changePos[2, 0] = posNum[2, 0, 0];
        changePos[2, 1] = posNum[2, 1, 0];
        changePos[2, 2] = posNum[2, 2, 0];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[2, j, k] = changePos[j, k];
                posNum[2, j, k].SetPosition(2, j, k);
            }
        }
    }
    //橙の面を左に回す
    public void OplusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 0];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.right));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 2, 0];
        changePos[0, 1] = posNum[1, 2, 0];
        changePos[0, 2] = posNum[2, 2, 0];
        changePos[1, 0] = posNum[0, 1, 0];
        changePos[1, 1] = posNum[1, 1, 0];
        changePos[1, 2] = posNum[2, 1, 0];
        changePos[2, 0] = posNum[0, 0, 0];
        changePos[2, 1] = posNum[1, 0, 0];
        changePos[2, 2] = posNum[2, 0, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 0] = changePos[i, j];
                posNum[i, j, 0].SetPosition(i, j, 0);
            }
        }
    }
    //橙の面を右に回す
    public void OminusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 0];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.left));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 0, 0];
        changePos[0, 1] = posNum[1, 0, 0];
        changePos[0, 2] = posNum[0, 0, 0];
        changePos[1, 0] = posNum[2, 1, 0];
        changePos[1, 1] = posNum[1, 1, 0];
        changePos[1, 2] = posNum[0, 1, 0];
        changePos[2, 0] = posNum[2, 2, 0];
        changePos[2, 1] = posNum[1, 2, 0];
        changePos[2, 2] = posNum[0, 2, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 0] = changePos[i, j];
                posNum[i, j, 0].SetPosition(i, j, 0);
            }
        }
    }
    //白の面を左に回す
    public void WplusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 0, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.up));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 0, 2];
        changePos[0, 1] = posNum[1, 0, 2];
        changePos[0, 2] = posNum[2, 0, 2];
        changePos[1, 0] = posNum[0, 0, 1];
        changePos[1, 1] = posNum[1, 0, 1];
        changePos[1, 2] = posNum[2, 0, 1];
        changePos[2, 0] = posNum[0, 0, 0];
        changePos[2, 1] = posNum[1, 0, 0];
        changePos[2, 2] = posNum[2, 0, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 0, k] = changePos[i, k];
                posNum[i, 0, k].SetPosition(i, 0, k);
            }
        }
    }
    //白の面を右に回す
    public void WminusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 0, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.down));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 0, 0];
        changePos[0, 1] = posNum[1, 0, 0];
        changePos[0, 2] = posNum[0, 0, 0];
        changePos[1, 0] = posNum[2, 0, 1];
        changePos[1, 1] = posNum[1, 0, 1];
        changePos[1, 2] = posNum[0, 0, 1];
        changePos[2, 0] = posNum[2, 0, 2];
        changePos[2, 1] = posNum[1, 0, 2];
        changePos[2, 2] = posNum[0, 0, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 0, k] = changePos[i, k];
                posNum[i, 0, k].SetPosition(i, 0, k);
            }
        }
    }
    //黄の面を左に回す
    public void YminusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 2, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.down));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 2, 0];
        changePos[0, 1] = posNum[1, 2, 0];
        changePos[0, 2] = posNum[0, 2, 0];
        changePos[1, 0] = posNum[2, 2, 1];
        changePos[1, 1] = posNum[1, 2, 1];
        changePos[1, 2] = posNum[0, 2, 1];
        changePos[2, 0] = posNum[2, 2, 2];
        changePos[2, 1] = posNum[1, 2, 2];
        changePos[2, 2] = posNum[0, 2, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 2, k] = changePos[i, k];
                posNum[i, 2, k].SetPosition(i, 2, k);
            }
        }
    }
    //黄の面を右に回す
    public void YplusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 2, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.up));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 2, 2];
        changePos[0, 1] = posNum[1, 2, 2];
        changePos[0, 2] = posNum[2, 2, 2];
        changePos[1, 0] = posNum[0, 2, 1];
        changePos[1, 1] = posNum[1, 2, 1];
        changePos[1, 2] = posNum[2, 2, 1];
        changePos[2, 0] = posNum[0, 2, 0];
        changePos[2, 1] = posNum[1, 2, 0];
        changePos[2, 2] = posNum[2, 2, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 2, k] = changePos[i, k];
                posNum[i, 2, k].SetPosition(i, 2, k);
            }
        }
    }
    //真ん中(Core)をX軸にしたがって正方向に回す
    public void CplusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 1];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.right));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 2, 1];
        changePos[0, 1] = posNum[1, 2, 1];
        changePos[0, 2] = posNum[2, 2, 1];
        changePos[1, 0] = posNum[0, 1, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[2, 1, 1];
        changePos[2, 0] = posNum[0, 0, 1];
        changePos[2, 1] = posNum[1, 0, 1];
        changePos[2, 2] = posNum[2, 0, 1];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 1] = changePos[i, j];
                posNum[i, j, 1].SetPosition(i, j, 1);
            }
        }
    }
    //真ん中(Core)をX軸にしたがって負方向に回す
    public void CminusX()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes[i * 3 + j] = posNum[i, j, 1];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.left));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 0, 1];
        changePos[0, 1] = posNum[1, 0, 1];
        changePos[0, 2] = posNum[0, 0, 1];
        changePos[1, 0] = posNum[2, 1, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[0, 1, 1];
        changePos[2, 0] = posNum[2, 2, 1];
        changePos[2, 1] = posNum[1, 2, 1];
        changePos[2, 2] = posNum[0, 2, 1];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 1] = changePos[i, j];
                posNum[i, j, 1].SetPosition(i, j, 1);
            }
        }
    }
    //真ん中(Core)をY軸にしたがって正方向に回す
    public void CplusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 1, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.up));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[0, 1, 2];
        changePos[0, 1] = posNum[1, 1, 2];
        changePos[0, 2] = posNum[2, 1, 2];
        changePos[1, 0] = posNum[0, 1, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[2, 1, 1];
        changePos[2, 0] = posNum[0, 1, 0];
        changePos[2, 1] = posNum[1, 1, 0];
        changePos[2, 2] = posNum[2, 1, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 1, k] = changePos[i, k];
                posNum[i, 1, k].SetPosition(i, 1, k);
            }
        }
    }
    //真ん中(Core)をY軸にしたがって負方向に回す
    public void CminusY()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[i * 3 + k] = posNum[i, 1, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.down));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[2, 1, 0];
        changePos[0, 1] = posNum[1, 1, 0];
        changePos[0, 2] = posNum[0, 1, 0];
        changePos[1, 0] = posNum[2, 1, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[0, 1, 1];
        changePos[2, 0] = posNum[2, 1, 2];
        changePos[2, 1] = posNum[1, 1, 2];
        changePos[2, 2] = posNum[0, 1, 2];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 1, k] = changePos[i, k];
                posNum[i, 1, k].SetPosition(i, 1, k);
            }
        }
    }
    //真ん中(Core)をZ軸にしたがって正方向に回す
    public void CplusZ()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[1, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.forward));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[1, 0, 2];
        changePos[0, 1] = posNum[1, 1, 2];
        changePos[0, 2] = posNum[1, 2, 2];
        changePos[1, 0] = posNum[1, 0, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[1, 2, 1];
        changePos[2, 0] = posNum[1, 0, 0];
        changePos[2, 1] = posNum[1, 1, 0];
        changePos[2, 2] = posNum[1, 2, 0];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[1, j, k] = changePos[j, k];
                posNum[1, j, k].SetPosition(1, j, k);
            }
        }
    }
    //真ん中(Core)をZ軸にしたがって負方向に回す
    public void CminusZ()
    {
        CubesPosition[] rotCubes = new CubesPosition[9];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes[j * 3 + k] = posNum[1, j, k];
            }
        }
        StartCoroutine(RotateAnimation(rotCubes, Vector3.back));
        CubesPosition[,] changePos = new CubesPosition[3, 3];
        changePos[0, 0] = posNum[1, 2, 0];
        changePos[0, 1] = posNum[1, 1, 0];
        changePos[0, 2] = posNum[1, 0, 0];
        changePos[1, 0] = posNum[1, 2, 1];
        changePos[1, 1] = posNum[1, 1, 1];
        changePos[1, 2] = posNum[1, 0, 1];
        changePos[2, 0] = posNum[1, 2, 2];
        changePos[2, 1] = posNum[1, 1, 2];
        changePos[2, 2] = posNum[1, 0, 2];
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[1, j, k] = changePos[j, k];
                posNum[1, j, k].SetPosition(1, j, k);
            }
        }
    }
    /*
    IEnumerator RotateCore(CubesPosition[] rotCubes1, CubesPosition[] rotCubes2, Vector3 vec)
    {
        rottime = true;
        for (int k = 0; k < 9; k++)
        {
            rotCubes1[k].Switch();
            rotCubes2[k].Switch();
            rotCubes1[k].gameObject.transform.parent = axis.transform;
            rotCubes2[k].gameObject.transform.parent = axis.transform;
        }

        for (int j = 0; j < 45; j++)
        {
            yield return new WaitForSeconds(0.01f);
            Quaternion rot = Quaternion.AngleAxis(-2, vec);
            Quaternion q = axis.transform.rotation;

            Quaternion rotB = Quaternion.AngleAxis(2, vec);
            Quaternion qB = Body.transform.rotation;

            axis.transform.rotation = q * rot;
            Body.transform.rotation = qB * rotB;
        }

        for (int l = 0; l < 9; l++)
        {
            rotCubes1[l].Switch();
            rotCubes2[l].Switch();
            rotCubes1[l].gameObject.transform.parent = this.gameObject.transform;
            rotCubes2[l].gameObject.transform.parent = this.gameObject.transform;
        }
        axis.transform.localEulerAngles = new Vector3(0, 0, 0);

        rottime = false;
    }
    //真ん中(Core)をX軸にしたがって正方向に回す
    public void CplusX()
    {
        CubesPosition[] rotCubes1 = new CubesPosition[9];
        CubesPosition[] rotCubes2 = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes1[i * 3 + j] = posNum[i, j, 0];
                rotCubes2[i * 3 + j] = posNum[i, j, 2];
            }
        }
        StartCoroutine(RotateCore(rotCubes1, rotCubes2, Vector3.right));
        CubesPosition[,] changePos1 = new CubesPosition[3, 3];
        CubesPosition[,] changePos2 = new CubesPosition[3, 3];
        changePos1[0, 0] = posNum[2, 0, 0];
        changePos1[0, 1] = posNum[1, 0, 0];
        changePos1[0, 2] = posNum[0, 0, 0];
        changePos1[1, 0] = posNum[2, 1, 0];
        changePos1[1, 1] = posNum[1, 1, 0];
        changePos1[1, 2] = posNum[0, 1, 0];
        changePos1[2, 0] = posNum[2, 2, 0];
        changePos1[2, 1] = posNum[1, 2, 0];
        changePos1[2, 2] = posNum[0, 2, 0];

        changePos2[0, 0] = posNum[2, 0, 2];
        changePos2[0, 1] = posNum[1, 0, 2];
        changePos2[0, 2] = posNum[0, 0, 2];
        changePos2[1, 0] = posNum[2, 1, 2];
        changePos2[1, 1] = posNum[1, 1, 2];
        changePos2[1, 2] = posNum[0, 1, 2];
        changePos2[2, 0] = posNum[2, 2, 2];
        changePos2[2, 1] = posNum[1, 2, 2];
        changePos2[2, 2] = posNum[0, 2, 2];


        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 0] = changePos1[i, j];
                posNum[i, j, 2] = changePos2[i, j];
                posNum[i, j, 0].SetPosition(i, j, 0);
                posNum[i, j, 2].SetPosition(i, j, 2);
            }
        }
    }
    //真ん中(Core)をX軸にしたがって負方向に回す
    public void CminusX()
    {
        CubesPosition[] rotCubes1 = new CubesPosition[9];
        CubesPosition[] rotCubes2 = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                rotCubes1[i * 3 + j] = posNum[i, j, 0];
                rotCubes2[i * 3 + j] = posNum[i, j, 2];
            }
        }
        StartCoroutine(RotateCore(rotCubes1, rotCubes2, Vector3.left));
        CubesPosition[,] changePos1 = new CubesPosition[3, 3];
        CubesPosition[,] changePos2 = new CubesPosition[3, 3];
        changePos1[0, 0] = posNum[0, 2, 0];
        changePos1[0, 1] = posNum[1, 2, 0];
        changePos1[0, 2] = posNum[2, 2, 0];
        changePos1[1, 0] = posNum[0, 1, 0];
        changePos1[1, 1] = posNum[1, 1, 0];
        changePos1[1, 2] = posNum[2, 1, 0];
        changePos1[2, 0] = posNum[0, 0, 0];
        changePos1[2, 1] = posNum[1, 0, 0];
        changePos1[2, 2] = posNum[2, 0, 0];

        changePos2[0, 0] = posNum[0, 2, 2];
        changePos2[0, 1] = posNum[1, 2, 2];
        changePos2[0, 2] = posNum[2, 2, 2];
        changePos2[1, 0] = posNum[0, 1, 2];
        changePos2[1, 1] = posNum[1, 1, 2];
        changePos2[1, 2] = posNum[2, 1, 2];
        changePos2[2, 0] = posNum[0, 0, 2];
        changePos2[2, 1] = posNum[1, 0, 2];
        changePos2[2, 2] = posNum[2, 0, 2];


        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                posNum[i, j, 0] = changePos1[i, j];
                posNum[i, j, 2] = changePos2[i, j];
                posNum[i, j, 0].SetPosition(i, j, 0);
                posNum[i, j, 2].SetPosition(i, j, 2);
            }
        }
    }
    //真ん中(Core)をY軸にしたがって正方向に回す
    public void CplusY()
    {
        CubesPosition[] rotCubes1 = new CubesPosition[9];
        CubesPosition[] rotCubes2 = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes1[i * 3 + k] = posNum[i, 0, k];
                rotCubes2[i * 3 + k] = posNum[i, 2, k];
            }
        }
        StartCoroutine(RotateCore(rotCubes1, rotCubes2, Vector3.up));
        CubesPosition[,] changePos1 = new CubesPosition[3, 3];
        CubesPosition[,] changePos2 = new CubesPosition[3, 3];

        changePos1[0, 0] = posNum[2, 0, 0];
        changePos1[0, 1] = posNum[1, 0, 0];
        changePos1[0, 2] = posNum[0, 0, 0];
        changePos1[1, 0] = posNum[2, 0, 1];
        changePos1[1, 1] = posNum[1, 0, 1];
        changePos1[1, 2] = posNum[0, 0, 1];
        changePos1[2, 0] = posNum[2, 0, 2];
        changePos1[2, 1] = posNum[1, 0, 2];
        changePos1[2, 2] = posNum[0, 0, 2];

        changePos2[0, 0] = posNum[2, 2, 0];
        changePos2[0, 1] = posNum[1, 2, 0];
        changePos2[0, 2] = posNum[0, 2, 0];
        changePos2[1, 0] = posNum[2, 2, 1];
        changePos2[1, 1] = posNum[1, 2, 1];
        changePos2[1, 2] = posNum[0, 2, 1];
        changePos2[2, 0] = posNum[2, 2, 2];
        changePos2[2, 1] = posNum[1, 2, 2];
        changePos2[2, 2] = posNum[0, 2, 2];

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 0, k] = changePos1[i, k];
                posNum[i, 2, k] = changePos2[i, k];
                posNum[i, 0, k].SetPosition(i, 0, k);
                posNum[i, 2, k].SetPosition(i, 2, k);
            }
        }
    }
    //真ん中(Core)をY軸にしたがって負方向に回す
    public void CminusY()
    {
        CubesPosition[] rotCubes1 = new CubesPosition[9];
        CubesPosition[] rotCubes2 = new CubesPosition[9];
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                rotCubes1[i * 3 + k] = posNum[i, 0, k];
                rotCubes2[i * 3 + k] = posNum[i, 2, k];
            }
        }
        StartCoroutine(RotateCore(rotCubes1, rotCubes2, Vector3.down));
        CubesPosition[,] changePos1 = new CubesPosition[3, 3];
        CubesPosition[,] changePos2 = new CubesPosition[3, 3];

        changePos1[0, 0] = posNum[0, 0, 2];
        changePos1[0, 1] = posNum[1, 0, 2];
        changePos1[0, 2] = posNum[2, 0, 2];
        changePos1[1, 0] = posNum[0, 0, 1];
        changePos1[1, 1] = posNum[1, 0, 1];
        changePos1[1, 2] = posNum[2, 0, 1];
        changePos1[2, 0] = posNum[0, 0, 0];
        changePos1[2, 1] = posNum[1, 0, 0];
        changePos1[2, 2] = posNum[2, 0, 0];

        changePos2[0, 0] = posNum[0, 2, 2];
        changePos2[0, 1] = posNum[1, 2, 2];
        changePos2[0, 2] = posNum[2, 2, 2];
        changePos2[1, 0] = posNum[0, 2, 1];
        changePos2[1, 1] = posNum[1, 2, 1];
        changePos2[1, 2] = posNum[2, 2, 1];
        changePos2[2, 0] = posNum[0, 2, 0];
        changePos2[2, 1] = posNum[1, 2, 0];
        changePos2[2, 2] = posNum[2, 2, 0];

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                posNum[i, 0, k] = changePos1[i, k];
                posNum[i, 2, k] = changePos2[i, k];
                posNum[i, 0, k].SetPosition(i, 0, k);
                posNum[i, 2, k].SetPosition(i, 2, k);
            }
        }
    }
    */
}
