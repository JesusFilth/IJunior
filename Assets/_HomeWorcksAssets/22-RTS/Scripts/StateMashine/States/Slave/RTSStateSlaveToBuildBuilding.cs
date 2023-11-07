using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    [RequireComponent(typeof(RTSSlave))]
    public class RTSStateSlaveToBuildBuilding : RTSState
    {
        private RTSSlave _slave;

        private void OnEnable()
        {
            if (_slave == null)
                _slave = GetComponent<RTSSlave>();

            _slave.ToBuildBuilding();

            if(_slave.LabelBuildBuilding.TryGetComponent(out RTSMainBase mainBase))
            {
                mainBase.AddSlave(_slave);
            }

            _slave.ToFree();
        }
    }
}
