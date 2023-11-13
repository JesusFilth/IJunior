using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    [RequireComponent(typeof(RTSBattleUnitMovement))]
    [RequireComponent(typeof(RTSBattleUnit))]
    public class RTSBattleTrigger : MonoBehaviour
    {
        [SerializeField] private FractionType _fraction;

        private List<RTSBattleUnit> _battleEnemyUnits = new List<RTSBattleUnit>();
        private List<RTSBattleDamageUnit> _battleDamageUnits = new List<RTSBattleDamageUnit>();

        private void Update()
        {
            CheckDeadEnemyUnits();
            CheckAttack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out RTSBattleUnit unit))
            {
                if (unit.Fraction == _fraction)
                    return;

                if(unit.IsDead() == false)
                    _battleEnemyUnits.Add(unit);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out RTSBattleUnit unit))
            {
                if (unit.Fraction == _fraction)
                    return;

                if(_battleEnemyUnits.Contains(unit))
                    _battleEnemyUnits.Remove(unit);
            }
        }

        private void CheckAttack()
        {
            if (_battleDamageUnits.Count == 0)
                return;

            if (_battleEnemyUnits.Count == 0)
                return;

            foreach (RTSBattleDamageUnit unit in _battleDamageUnits)
            {
                if (unit.IsAttacking() == false)
                {
                    unit.SetTargetAttack(_battleEnemyUnits[Random.Range(0,_battleEnemyUnits.Count)]);
                    break;
                }
            }
        }

        private void CheckDeadEnemyUnits()
        {
            List<RTSBattleDamageUnit> tempIsLife = _battleDamageUnits.Where(unit => unit.IsDead() == false).ToList();

            if (tempIsLife == null)
                return;

            foreach (var unit in tempIsLife)
            {
                _battleEnemyUnits.Remove(unit);
            }
        }
    }
}
