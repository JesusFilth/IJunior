using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateDie : State
{
    [SerializeField] private float _timeToDestroy = 3;

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimationData.Params.Dead);

        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, _timeToDestroy);
    }
}
