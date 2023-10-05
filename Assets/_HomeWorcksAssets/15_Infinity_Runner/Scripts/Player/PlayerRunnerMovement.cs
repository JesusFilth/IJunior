using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerRunnerMovement : MonoBehaviour
{
    [SerializeField] private float _step = 1f;
    [SerializeField] private float _speedStep = 2f;
    [SerializeField] private float _borderLeftPosition = -3f;
    [SerializeField] private float _borderRightPosition = 3f;

    private Animator _animator;
    private Vector3 _targetPosition = Vector3.zero;
    private Vector3 _startPosition;
    private IEnumerator _movingStep;
    private float _stopDistance = 0.01f;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    private void OnDisable()
    {
        if (_movingStep != null)
        {
            StopCoroutine(_movingStep);
            _movingStep = null;
        }
    }

    public bool TryLeftStep()
    {
        if (IsMovingStepEmpty() && TrySetNextPositioX(-_step))
        {
            _animator.SetTrigger(AnimatorDate.Params.LeftStep);
            MoveStep();

            return true;
        }

        return false;
    }

    public bool TryRightStep()
    {
        if (IsMovingStepEmpty() && TrySetNextPositioX(_step))
        {
            _animator.SetTrigger(AnimatorDate.Params.RightStep);
            MoveStep();

            return true;
        }

        return false;
    }

    private IEnumerator MovingStep()
    {
        while (Vector3.Distance(transform.position, _targetPosition) > _stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speedStep * Time.deltaTime);
            yield return null;
        }

        _movingStep = null;
    }

    private bool TrySetNextPositioX(float newPointX)
    {
        float newPositionX = transform.position.x + newPointX;

        if (newPositionX >= _borderLeftPosition && newPositionX <= _borderRightPosition)
        {
            _targetPosition = new Vector3(transform.position.x + newPointX, _startPosition.y, _startPosition.z);
            return true;
        }

        return false;
    }

    private void MoveStep()
    {
        if (IsMovingStepEmpty())
        {
            _movingStep = MovingStep();
            StartCoroutine(_movingStep);
        }
    }

    private bool IsMovingStepEmpty()
    {
        return _movingStep == null;
    }

    private class AnimatorDate
    {
        public class Params
        {
            public static int LeftStep = Animator.StringToHash(nameof(LeftStep));
            public static int RightStep = Animator.StringToHash(nameof(RightStep));
        }
    }
}
