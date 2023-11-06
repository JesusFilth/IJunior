using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RTS
{
    public abstract class RTSBuilding : MonoBehaviour
    {
        [SerializeField] private string _gameStatsTag = "GameStats";

        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected bool _isActive;
        [Space]
        [SerializeField] private List<RTSBuildingAction> _buildingProducts;

        public List<RTSBuildingAction> BuildingProducts => _buildingProducts;

        protected RTSGameStats _gameStats;
        public bool IsActive => _isActive;

        public abstract void Init();

        public string GetName()
        {
            return Name;
        }

        private void OnEnable()
        {
            if(GameObject.FindGameObjectWithTag(_gameStatsTag).TryGetComponent(out RTSGameStats gameeStats))
            {
                _gameStats = gameeStats;
            }
        }
    }
}
