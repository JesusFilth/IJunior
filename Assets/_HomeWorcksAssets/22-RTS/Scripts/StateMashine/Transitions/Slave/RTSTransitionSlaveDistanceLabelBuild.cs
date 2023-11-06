using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    [RequireComponent(typeof(RTSSlaveMovement))]
    public class RTSTransitionSlaveDistanceLabelBuild : RTSTransition
    {
        [SerializeField] private float _distance = 0.2f;

        private RTSSlave _slave;
        private RTSSlaveMovement _slaveMovement;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
            _slaveMovement = GetComponent<RTSSlaveMovement>();
        }

        private void Update()
        {
            if (_slave.LabelBuildBuilding == null)
                return;

            if (Vector3.Distance(transform.position, _slave.LabelBuildBuilding.transform.position) <= _distance)
            {
                _slaveMovement.ToIdel();
                NeedTransit = true;
            }
        }
    }
}
