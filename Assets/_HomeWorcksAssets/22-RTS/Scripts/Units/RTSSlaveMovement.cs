using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(RTSSlave))]
public class RTSSlaveMovement : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private RTSSlave _slave;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _slave = GetComponent<RTSSlave>();
    }

    public void ToIdel()
    {
        if (_animator == null)
            return;

        _agent.ResetPath();
        _animator.SetBool(RTSAnimationData.Params.IsWalk, false);
        _animator.SetBool(RTSAnimationData.Params.IsCarry, false);
    }

    public void MoveToTarget()
    {
        if (_slave == null || _slave.CurrentTarget == null)
            return;

        if (_slave.IsCarry)
            _animator.SetBool(RTSAnimationData.Params.IsCarry, true);

        _agent.SetDestination(_slave.CurrentTarget.position);
        _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
    }

    public void MoveToMainBase_()
    {
        if (_slave.IsHasMainBase() == false)
            return;

        RTSMainBase mainBase = _slave.Building as RTSMainBase;

        if (mainBase == null)
            return;

        _agent.SetDestination(mainBase.PutOnMineralPoint.position);
        _animator.SetBool(RTSAnimationData.Params.IsCarry, true);
        _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
    }

    public void ToPickUp()
    {
        _agent.ResetPath();
        _animator.SetBool(RTSAnimationData.Params.IsWalk, false);
        _animator.SetTrigger(RTSAnimationData.Params.PickUp);
    }
}
