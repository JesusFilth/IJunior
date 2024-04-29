using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._HomeWorcksAssets._11_Platformer.Scripts
{
    public class Stat : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth { get; private set; }
        public bool IsDead => CurrentHealth <= 0;

        public event Action<float> HealthChanged;
        public event Action Died;

        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        private void Start()
        {
            HealthChanged?.Invoke(GetPercentCurrentHealth());
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, _maxHealth);
            HealthChanged?.Invoke(GetPercentCurrentHealth());

            if (CurrentHealth <= 0)
                Died?.Invoke();
        }

        public void TakeHeal(float heal)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, _maxHealth);
            HealthChanged?.Invoke(GetPercentCurrentHealth());
        }

        private float GetPercentCurrentHealth()
        {
            if(IsDead || MaxHealth == 0)
                return 0;

            const float MaxPercent = 100;

            return (MaxPercent / (_maxHealth / CurrentHealth)) / MaxPercent;
        }
    }
}
