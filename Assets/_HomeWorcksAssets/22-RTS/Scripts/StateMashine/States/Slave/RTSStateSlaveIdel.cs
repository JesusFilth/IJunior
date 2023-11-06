using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSSlaveMovement))]
[RequireComponent(typeof(RTSSlave))]
public class RTSStateSlaveIdel : RTSState
{
    private RTSSlaveMovement _slaveMovement;
    private RTSSlave _slave;

    private void OnEnable()
    {
        if(_slaveMovement==null)
            _slaveMovement = GetComponent<RTSSlaveMovement>();

        if(_slave==null)
            _slave = GetComponent<RTSSlave>();

        _slaveMovement.ToIdel();
        _slave.ToFree();
    }
}
