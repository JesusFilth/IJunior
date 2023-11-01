using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public abstract class RTSBuilding : MonoBehaviour
    {
        [SerializeField] protected RTSGameStats _gameStats;

        public virtual void Init(RTSGameStats stats)
        {
            _gameStats = stats;
        }
    }
}
