using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSTransitionSlaveIsEmptyCurrentTarget : RTSTransition
    {
        private RTSSlave _slave;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
        }

        private void Update()
        {
            if (_slave.CurrentTarget == null)
                NeedTransit = true;
        }
    }
}
