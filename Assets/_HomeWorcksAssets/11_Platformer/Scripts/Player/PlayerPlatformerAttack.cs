using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerPlatformer))]
public class PlayerPlatformerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _rayAttackDistance = 2f; 
    [SerializeField] private float _rayOffsetY = 0.5f;
    [SerializeField] private LayerMask _layerMask;

    private Animator _animator;
    private PlayerPlatformer _player;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<PlayerPlatformer>();
    }

    private void Update()
    {
        if (_player.IsDead())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(AnimationData.Params.Attack);

            Vector3 rayDirection = transform.rotation * Vector3.right;
            Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y + _rayOffsetY);

            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayDirection, _rayAttackDistance, _layerMask);
            Debug.DrawRay(rayPosition, rayDirection, Color.red);

            if (hit.collider != null)
                if (hit.collider.TryGetComponent(out EnemyPlatformer enemy))
                    enemy.TakeDamage(_damage);
        }
    }
}
