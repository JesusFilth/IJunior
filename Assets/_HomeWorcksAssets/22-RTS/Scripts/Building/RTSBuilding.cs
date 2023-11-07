using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RTS
{
    public abstract class RTSBuilding : MonoBehaviour
    {
        [SerializeField] private string _gameStatsTag = "GameManager";

        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected int Price;
        [SerializeField] protected bool _isActive;
        [Space][SerializeField] private List<RTSBuildingAction> _buildingProducts;

        public bool IsActive => _isActive;
        public List<RTSBuildingAction> BuildingProducts => _buildingProducts;

        protected RTSGameStats _gameStats;

        public bool HasMineralForBuild() => Price <= _gameStats.Minerals;

        private void OnEnable()
        {
            if(GameObject.FindGameObjectWithTag(_gameStatsTag).TryGetComponent(out RTSGameStats gameeStats))
            {
                _gameStats = gameeStats;
            }
        }

        public abstract void Init();

        public string GetName()
        {
            return Name;
        }
    }
}
