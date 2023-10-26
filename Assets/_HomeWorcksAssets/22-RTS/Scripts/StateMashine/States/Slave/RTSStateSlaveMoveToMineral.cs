using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSSlaveMovement))]
public class RTSStateSlaveMoveToMineral : RTSState
{
    private RTSSlaveMovement _slaveMovement;

    private void OnEnable()
    {
        if(_slaveMovement==null)
            _slaveMovement = GetComponent<RTSSlaveMovement>();

        _slaveMovement.MoveToMineral();
    }

    private void OnDisable()
    {
        _slaveMovement.ToIdel();
    }
}
