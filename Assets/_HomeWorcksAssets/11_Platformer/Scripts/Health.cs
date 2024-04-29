using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._HomeWorcksAssets._11_Platformer.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxValue;

        public float MaxValue => _maxValue;
        public float CurrentValue { get; private set; }
        public bool IsDead => CurrentValue <= 0;

        public event Action<float> ValueChanged;
        public event Action Died;

        private void Awake()
        {
            CurrentValue = _maxValue;
        }

        private void Start()
        {
            ValueChanged?.Invoke(GetPercentCurrentValue());
        }

        public void TakeDamage(float damage)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - damage, 0, _maxValue);
            ValueChanged?.Invoke(GetPercentCurrentValue());

            if (CurrentValue <= 0)
                Died?.Invoke();
        }

        public void TakeHeal(float heal)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + heal, 0, _maxValue);
            ValueChanged?.Invoke(GetPercentCurrentValue());
        }

        private float GetPercentCurrentValue()
        {
            if(IsDead || MaxValue == 0)
                return 0;

            const float MaxPercent = 100;

            return (MaxPercent / (_maxValue / CurrentValue)) / MaxPercent;
        }
    }
}
