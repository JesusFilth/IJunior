using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSTransitionSlaveWaitFreeMineral : RTSTransition
    {
        private RTSSlave _slave;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
        }

        private void Update()
        {
            if (_slave.IsHasCurrentMineral())
            {
                _slave.ToWork();
                NeedTransit = true;
            }
        }
    }
}
