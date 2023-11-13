using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(RTSBattleDamageUnit))]
    public class RTSBattleUnitMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private RTSBattleDamageUnit _unit;
        private Animator _animator;

        private void OnEnable()
        {
            _agent = GetComponent<NavMeshAgent>();
            _unit = GetComponent<RTSBattleDamageUnit>();
            _animator = GetComponent<Animator>();

            MoveToTarget();
        }

        public void MoveToTarget()
        {
            if (_unit.IsAttacking())
                return;
                
            ResetMovement();
           // _agent.SetDestination(_unit.TargetMove.position);
            _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
        }

        public void Attack()
        {
            ResetMovement();
            _animator.SetBool(RTSAnimationData.Params.IsAttack, true);
        }

        public void ResetMovement()
        {
            _agent.ResetPath();
            _animator.SetBool(RTSAnimationData.Params.IsWalk, false);
            _animator.SetBool(RTSAnimationData.Params.IsAttack, false);
        }
    }
}
