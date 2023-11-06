using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSTransitionSlaveWaitToGoMineral : RTSTransition
    {
        private RTSSlave _slave;
        private RTSSlaveMovement _slaveMovement;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
            _slaveMovement = GetComponent<RTSSlaveMovement>();
        }

        private void Update()
        {
            if (_slave.IsHasCurrentMineral())
            {
                NeedTransit = true;
            }
        }
    }
}
