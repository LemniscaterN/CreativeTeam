using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPosition : MonoBehaviour
{
    private float posX, posY, posZ;
    //private float rotX = 0, rotY = 0, rotZ = 0;
    private bool rotateTime = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateTime == false)
        {
            transform.localPosition = new Vector3(posX, posY, posZ);
            //SetRotation();
            //transform.localEulerAngles = new Vector3(rotX, rotY, rotZ);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void SetPosition(int i ,int j,int k)
    {
        posX = 1.01f * (k - 1);
        posY = -1.01f * (j - 1);
        posZ = 1.01f * (i - 1);
    }

    /*public void SetRotation()
    {
        SetRotationX();
        SetRotationY();
        SetRotationZ();
    }

    public void SetRotationX()
    {
        Vector3 nowRot = transform.localEulerAngles;
        if (nowRot.x < 45 && nowRot.x > -45)
        {
            rotX = 0;
        } else if (nowRot.x < 135 && nowRot.x > 45)
        {
            rotX = 90;
        } else if (nowRot.x < 225 && nowRot.x > 135)
        {
            rotX = 180;
        } else if (nowRot.x < -45 && nowRot.x > -135)
        {
            rotX = -90;
        }
    }

    public void SetRotationY() {
        Vector3 nowRot = transform.localEulerAngles;
        if (nowRot.y < 45 && nowRot.y > -45)
        {
            rotY = 0;
        }
        else if (nowRot.y < 135 && nowRot.y > 45)
        {
            rotY = 90;
        }
        else if (nowRot.y < 225 && nowRot.y > 135)
        {
            rotY = 180;
        }
        else if (nowRot.y < -45 && nowRot.y > -135)
        {
            rotY = -90;
        }
    }

    public void SetRotationZ() {
        Vector3 nowRot = transform.localEulerAngles;
        if (nowRot.z < 45 && nowRot.z > -45)
        {
            rotZ = 0;
        }
        else if (nowRot.z < 135 && nowRot.z > 45)
        {
            rotZ = 90;
        }
        else if (nowRot.z < 225 && nowRot.z > 135)
        {
            rotZ = 180;
        }
        else if (nowRot.z < -45 && nowRot.z > -135)
        {
            rotZ = -90;
        }


    }
    */

    public void Switch()
    {
        if (rotateTime == false)
        {
            rotateTime = true;
        }else if (rotateTime == true)
        {
            rotateTime = false;
        }
    }
}
