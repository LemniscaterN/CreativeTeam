using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3((float)0, (float)0.5, (float)0.5));
    }
}
