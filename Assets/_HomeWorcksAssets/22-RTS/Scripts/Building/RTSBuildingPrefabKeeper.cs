using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSBuildingPrefabKeeper : MonoBehaviour
    {
        [SerializeField] private RTSConstructionBuildingLabel _originalPrefab;

        public RTSConstructionBuildingLabel GetPrefab()
        {
            return _originalPrefab;
        }
    }
}
