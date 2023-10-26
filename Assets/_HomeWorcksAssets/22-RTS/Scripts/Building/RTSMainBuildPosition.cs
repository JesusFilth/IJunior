using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSMainBuildPosition : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out RTSSlave slave))
            {
                slave.PutOnMineral();
            }
        }
    }
}
