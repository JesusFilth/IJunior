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
        [SerializeField] private int _maxHealth;

        public int MaxHealth => _maxHealth;
        public int CurrentHealth { get; private set; }
        public bool IsDead => CurrentHealth <= 0;

        public event Action<int> HealthChanged;
        public event Action Died;

        private void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        private void Start()
        {
            HealthChanged?.Invoke(CurrentHealth);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, int.MaxValue);
            HealthChanged?.Invoke(CurrentHealth);

            if (CurrentHealth == 0)
                Died?.Invoke();
        }

        public void TakeHeal(int heal)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + heal, 0, _maxHealth);
            HealthChanged?.Invoke(CurrentHealth);
        }
    }
}
