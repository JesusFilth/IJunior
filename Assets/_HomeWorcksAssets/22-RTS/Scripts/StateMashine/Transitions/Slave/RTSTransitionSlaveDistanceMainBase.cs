using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSTransitionSlaveDistanceMainBase : RTSTransition
    {
        [SerializeField] private float _distance = 0.2f;

        private RTSSlave _slave;
        private RTSSlaveMovement _slaveMovement;
        private RTSMainBase _mainBase;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
            _slaveMovement = GetComponent<RTSSlaveMovement>();
            _mainBase = _slave.Building as RTSMainBase;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _mainBase.PutOnMineralPoint.position) <= _distance)
            {
                _slaveMovement.ToIdel();
                NeedTransit = true;
            }
        }
    }
}
