using System;
using UnityEngine;
using UnityEngine.Events;

namespace RTS
{
    [Serializable]
    public class RTSBuildingAction
    {
        [SerializeField] private UnityEvent _action;
        [SerializeField] private string _description;
        [SerializeField] private int _mineralPrice;
        [SerializeField] private Sprite _icon;

        public UnityEvent Action => _action;
        public string Description => _description;
        public int MineralPrice => _mineralPrice;
        public Sprite Icon => _icon;
    }
}
