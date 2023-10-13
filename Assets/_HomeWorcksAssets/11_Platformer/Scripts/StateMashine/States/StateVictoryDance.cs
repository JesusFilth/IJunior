using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateVictoryDance : State
{
    private Animator _animator;

    private void OnEnable()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();

        _animator.SetTrigger(AnimationData.Params.IsVictory);
    }
}
