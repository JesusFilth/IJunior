using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSSlaveMovement))]
public class RTSStateSlaveIdel : RTSState
{
    private RTSSlaveMovement _slaveMovement;

    private void OnEnable()
    {
        if(_slaveMovement==null)
            _slaveMovement = GetComponent<RTSSlaveMovement>();

        _slaveMovement.ToIdel();
    }
}
