using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RTS
{
    public class RTSGameStats : MonoBehaviour
    {
        public int Minerals { get; private set; }

        public UnityAction<int> MineralChanged;

        private void Start()
        {
            MineralChanged?.Invoke(Minerals);
        }

        public void AddMineral(int mineral)
        {
            Minerals = Mathf.Clamp(Minerals+=mineral, 0, int.MaxValue);
            MineralChanged?.Invoke(Minerals);
        }
    }
}
