using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSStareSlavePutOnMineralOnMainBase : RTSState
    {
        private RTSSlave _slave;
        private RTSSlaveMovement _slaveMovement;

        private void OnEnable()
        {
            if(_slave==null)
                _slave = GetComponent<RTSSlave>();

            if(_slaveMovement == null)
                _slaveMovement = GetComponent<RTSSlaveMovement>();

            _slave.PutOnMineral();
            _slave.ToFree();
            _slaveMovement.ToIdel();
        }
    }
}
