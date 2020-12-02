namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CubeMakeScript : MonoBehaviour
    {
        [SerializeField]
        private PanelScript[] ps = null;

        private PanelScript[,] panels = new PanelScript[6, 9];

        // Start is called before the first frame update

        void Start()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    panels[i, j] = ps[i * 9 + j];
                    panels[i, j].changecolor(CubeInspection.colorArray[i, j]);
                    //panels[i, j].changecolor((color)Random.RandomRange(0, 6));
                }
            }
        }
    }
}
