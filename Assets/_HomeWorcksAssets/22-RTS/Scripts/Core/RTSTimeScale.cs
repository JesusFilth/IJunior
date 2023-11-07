using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSTimeScale : MonoBehaviour
    {
        public void X1()
        {
            Time.timeScale = 1.0f;
        }

        public void X2()
        {
            Time.timeScale = 2.0f;
        }

        public void X3()
        {
            Time.timeScale = 3.0f;
        }
    }
}
