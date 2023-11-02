using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public abstract class RTSUnit : MonoBehaviour
    {
        [SerializeField] private RTSBuilding _building;
        public RTSBuilding Building => _building;

        public virtual void Init(RTSBuilding building)
        {
            _building = building;
        }
    }
}
