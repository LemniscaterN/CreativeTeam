using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMakeScript : MonoBehaviour
{
    [SerializeField]
    private PanelScript[] ps = null;

    // Start is called before the first frame update
    
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            color j = (color)1;
            ps[i].changecolor(j);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
