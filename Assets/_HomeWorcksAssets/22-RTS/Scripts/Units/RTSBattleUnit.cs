using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS
{
    public class RTSBattleUnit : MonoBehaviour
    {
        [SerializeField] protected int _maxHealth = 10;
        [SerializeField] protected FractionType _fraction;

        [SerializeField] protected Animator _animator;

        public FractionType Fraction => _fraction;
        public int MaxHealth => _maxHealth;
        public int Health { get; protected set; }

        public bool IsDead() => Health <= 0;

        private void OnEnable()
        {
            Init();
        }

        protected virtual void Init()
        {
            Health = _maxHealth;
        }

        public void ChangeHealth(int health)
        {
            Health = Mathf.Clamp(Health += health, 0, _maxHealth);

            if (IsDead())
            {
                _animator.SetTrigger(RTSAnimationData.Params.IsDead);
            }
        }
    }

    public enum FractionType
    {
        Good,
        Bad
    }
}
