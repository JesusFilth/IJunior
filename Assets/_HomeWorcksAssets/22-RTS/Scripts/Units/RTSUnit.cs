using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public abstract class RTSUnit : MonoBehaviour
    {
        [SerializeField] private RTSBuilding _building;
        [SerializeField] private int _price;
        public RTSBuilding Building => _building;
        public int Price => _price;

        public virtual void Init(RTSBuilding building)
        {
            _building = building;
        }
    }
}
