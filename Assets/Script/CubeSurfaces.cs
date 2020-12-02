namespace OpenCvSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CubeSurfaces : MonoBehaviour
    {
        [SerializeField]
        private Surface_Script[] _sur = null;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void pasting(int _num)
        {
            _sur[_num].done = true;
        }
    }
}
