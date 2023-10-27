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

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _slave = GetComponent<RTSSlave>();
    }

    public void ToIdel()
    {
        _animator.SetBool(RTSAnimationData.Params.IsWalk, false);
        _animator.SetBool(RTSAnimationData.Params.IsCarry, false);
        //_agent.ResetPath();
    }

    public void MoveToMineral()
    {
        if (_slave.IsHasCurrentMineral() == false)
            return;

        _agent.SetDestination(_slave.CurrentMineral.transform.position);
        _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
    }

    public void MoveToMainBase()
    {
        if (_slave.IsHasMainBase() == false)
            return;

        _agent.SetDestination(_slave.MainBase.position);
        _animator.SetBool(RTSAnimationData.Params.IsCarry, true);
        _animator.SetBool(RTSAnimationData.Params.IsWalk, true);
    }

    public void ToPickUp()
    {
        _agent.ResetPath();
        _animator.SetTrigger(RTSAnimationData.Params.PickUp);
    }
}
