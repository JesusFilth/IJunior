using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSStareSlavePutOnMineralOnMainBase : RTSState
    {
        private RTSSlave _slave;

        private void OnEnable()
        {
            if(_slave==null)
                _slave = GetComponent<RTSSlave>();

            _slave.PutOnMineral();
        }
    }
}
