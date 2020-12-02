namespace OpenCvSharp {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CubeInspection : MonoBehaviour
    {
        [SerializeField]
        private ColorDiscrimination _CD = null;
        [SerializeField]
        private Cube _cube = null;
        [SerializeField]
        private Solve _solve = null;

        static public color[,] colorArray = new color[6, 9];

        //public Texture2D _tex;

        // Start is called before the first frame update
        public int Inspection(int Surface,int i,Texture2D tex)
        {
            _CD.texture = tex;
            int colorNum = _CD.Color_discrimination();
            colorArray[Surface, i] = (color)colorNum;
            //Debug.Log(colorNum);
            return colorNum;
        }

        public void Cube_Solve()
        {
            for(int i = 0; i < 54; i++)
            {
                Debug.Log(colorArray[i / 9, i % 9]);
            }
            _cube.SetFaceColors(colorArray);
            Debug.Log(_solve.MakeSolution(_cube));
        }
    }
}
