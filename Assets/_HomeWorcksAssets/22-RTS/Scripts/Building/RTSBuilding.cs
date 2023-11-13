using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RTS
{
    public abstract class RTSBuilding : MonoBehaviour
    {
        [SerializeField] private const string GameStatsTag = "GameManager";

        [SerializeField] protected string Name;
        [SerializeField] protected string Description;
        [SerializeField] protected bool _isActive;
        [SerializeField] protected int _price;

        [Space][SerializeField] private List<RTSBuildingAction> _buildingProducts;

        public int Price => _price;
        public bool IsActive => _isActive;
        public List<RTSBuildingAction> BuildingProducts => _buildingProducts;

        protected RTSGameStats _gameStats;

        public bool HasMineralForBuild() => _price <= _gameStats.Minerals;

        private void OnEnable()
        {
            if(GameObject.FindGameObjectWithTag(GameStatsTag).TryGetComponent(out RTSGameStats gameeStats))
            {
                _gameStats = gameeStats;
            }
        }

        public virtual void Init()
        {
            _isActive = true;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
