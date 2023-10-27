using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RTS
{
    public class RTSStats : MonoBehaviour
    {
        [SerializeField] private RTSMainBase _mainBase;

        [SerializeField] private TMP_Text _mineralText;

        private void OnEnable()
        {
            if (_mainBase != null)
                _mainBase.MineralChanged += ChangeMineral;
        }

        private void OnDisable()
        {
            if (_mainBase != null)
                _mainBase.MineralChanged -= ChangeMineral;
        }

        private void ChangeMineral(int mineral)
        {
            _mineralText.text = mineral.ToString();
        }
    }
}
