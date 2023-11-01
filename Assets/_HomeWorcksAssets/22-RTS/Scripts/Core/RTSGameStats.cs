using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RTS
{
    public class RTSGameStats : MonoBehaviour
    {
        private int _minerals = 0;

        public UnityAction<int> MineralChanged;

        private void Start()
        {
            MineralChanged?.Invoke(_minerals);
        }

        public void AddMineral(int mineral)
        {
            _minerals += mineral;
            MineralChanged?.Invoke(_minerals);
        }
    }
}
