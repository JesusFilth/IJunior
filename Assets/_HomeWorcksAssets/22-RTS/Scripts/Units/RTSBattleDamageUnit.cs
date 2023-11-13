using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RTS
{
    public class RTSBattleDamageUnit : RTSBattleUnit
    {
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected float _attackSpeed = 2;

        public int Damage => _damage;
        public float AttackSpeed => _attackSpeed;

        public bool IsAttacking() => _attacking != null;

        private RTSBattleUnit _targetAttack;
        private IEnumerator _attacking;
        private List<RTSBattleUnit> _battleEnemyUnits = new List<RTSBattleUnit>();

        private void OnDisable()
        {
            if (_attacking != null)
            {
                StopCoroutine(_attacking);
                _attacking = null;
            }
        }

        private void Update()
        {
            UpdateChain();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out RTSBattleUnit unit))
            {
                if (unit.Fraction == _fraction)
                    return;
                Debug.Log("OnTriggerEnter");
                if (unit.IsDead() == false)
                    _battleEnemyUnits.Add(unit);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out RTSBattleUnit unit))
            {
                if (unit.Fraction == _fraction)
                    return;

                if (_battleEnemyUnits.Contains(unit))
                    _battleEnemyUnits.Remove(unit);
            }
        }

        public void SetTargetAttack(RTSBattleUnit targetAttack)
        {
            if (targetAttack == null)
                return;

            _targetAttack = targetAttack;
        }

        protected virtual void UpdateChain()
        {
            CheckDeadEnemyUnits();

            if (CheckTargetAttack())
                Attack();

            RotateToTargetAttack();
        }

        protected bool CheckTargetAttack()
        {
            if (_battleEnemyUnits.Count == 0)
                return false;

            if (_attacking != null)
                return false;

            _targetAttack = _battleEnemyUnits[Random.Range(0, _battleEnemyUnits.Count)];
            return true;
        }

        private void CheckDeadEnemyUnits()
        {
            List<RTSBattleUnit> tempIsLife = _battleEnemyUnits.Where(unit => unit.IsDead()).ToList();

            if (tempIsLife == null)
                return;

            foreach (var unit in tempIsLife)
            {
                _battleEnemyUnits.Remove(unit);
            }
        }

        private void Attack()
        {
            if (_attacking != null)
            {
                StopCoroutine(_attacking);
                _attacking = null;
            }

            _attacking = Attacking();
            StartCoroutine(_attacking);
        }

        private void RotateToTargetAttack()
        {
            if (_targetAttack == null)
                return;

            transform.LookAt(_targetAttack.gameObject.transform);
        }

        private IEnumerator Attacking()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_attackSpeed);

            while (enabled)
            {
                if (_targetAttack.IsDead())
                {
                    _targetAttack = null;
                    break;
                }

                if (_animator != null)
                    _animator.SetTrigger(RTSAnimationData.Params.IsAttack);

                _targetAttack.ChangeHealth(-Damage);
                yield return waitForSeconds;
            }

            _attacking = null;
        }
    }
}
