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

            //_slave.LabelBuildBuilding.ToBuild();
            _slave.ToBuildBuilding();
            Debug.Log("тут можно улучшить еще");

            if(_slave.LabelBuildBuilding.TryGetComponent(out RTSMainBase mainBase))
            {
                mainBase.AddSleve(_slave);
            }

            _slave.ToFree();
        }
    }
}
