using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateAttack : State
{
    [SerializeField] private float _damage = 2f;
    [SerializeField] private float _delay;
    [SerializeField] private float _rayAttackDistance = 2f;
    [SerializeField] private float _rayOffsetY = 0.5f;
    [SerializeField] private LayerMask _layerMask;

    private float _lastAttackTime;
    private Animator _animator;

    private void OnEnable()
    {
        if(_animator==null)
            _animator = GetComponent<Animator>();

        _animator.SetTrigger(AnimationData.Params.Idel);
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        _animator.SetTrigger(AnimationData.Params.Attack);

        Vector3 rayDirection = transform.rotation * Vector3.right;
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y + _rayOffsetY);

        RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, _rayAttackDistance, _layerMask);
        Debug.DrawRay(rayPosition, rayDirection, Color.red);

        if (hit.collider != null)
            if (hit.collider.TryGetComponent(out Health player))
                player.TakeDamage(_damage);
    }
}
