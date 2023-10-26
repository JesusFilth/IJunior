using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSTransitionSlavePickUpBusy : RTSTransition
    {
        private RTSSlave _slave;

        private void Start()
        {
            _slave = GetComponent<RTSSlave>();
        }

        private void Update()
        {
            if (_slave.IsBusy == false)
                NeedTransit = true;
        }
    }
}
