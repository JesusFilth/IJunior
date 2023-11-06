using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSStateSlaveMoveToCurrentTarget : RTSState
    {
        private RTSSlaveMovement _slaveMovment;

        private void OnEnable()
        {
            if(_slaveMovment==null)
                _slaveMovment = GetComponent<RTSSlaveMovement>();

            _slaveMovment.MoveToTarget();
        }
    }
}
