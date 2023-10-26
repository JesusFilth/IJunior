using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSTransitionSlaveDistanceMineral : RTSTransition
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out RTSMineralBox box))
            {
                NeedTransit = true;
            }
        }
    }
}
