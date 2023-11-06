using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSTransitionSlaveDistanceMineral : RTSTransition
    {
        [SerializeField] private float _distance = 1.5f;

        private RTSSlave _slave;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
        }

        private void Update()
        {
            if (_slave.CurrentMineral == null)
                return;

            if (Vector3.Distance(transform.position, _slave.CurrentMineral.transform.position) <= _distance)
            {
                NeedTransit = true;
            }
        }
    }
}
