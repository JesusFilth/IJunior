using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class RTSBattleDamageMovebleUnit : RTSBattleDamageUnit
    {
        [SerializeField] private Transform _targetDirection;
        [SerializeField] private bool _isMoving;

        private NavMeshAgent _agent;

        private void Start()
        {
            MoveToTarget();
            Debug.Log("Start Unit Moveble");
        }

        private void Update()
        {
            UpdateChain();
        }

        public void MoveToTarget()
        {
            if (_targetDirection == null)
                return;

            _isMoving = true;

            _agent.SetDestination(_targetDirection.transform.position);

            if (_animator != null)
                _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
        }

        public void StopMove()
        {
            _agent.ResetPath();

            if(_animator!=null)
                _animator.SetBool(RTSAnimationData.Params.IsWalk, false);

            _isMoving = false;
        }

        public void SetTargetMove(Transform target)
        {
            if (target == null)
                return;

            _targetDirection = target;
        }

        private void CheckTargetMove()
        {
            if (_isMoving == false)
                return;

            if (IsAttacking())
                StopMove();
        }

        protected override void Init()
        {
            base.Init();
            _agent = GetComponent<NavMeshAgent>();
        }

        protected override void UpdateChain()
        {
            base.UpdateChain();

            CheckTargetMove();
        }
    }
}
