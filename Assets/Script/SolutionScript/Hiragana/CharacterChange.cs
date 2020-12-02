using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    [SerializeField]
    private int surface = 0;
    [SerializeField]
    private int panel = 0;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<TextMesh>().text = CubeDefinitoin.PixelName[surface, panel];
    }
}
