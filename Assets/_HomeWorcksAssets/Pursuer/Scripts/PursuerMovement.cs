using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class PursuerMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistance = 2.0f;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _gravity = 20f;

    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void OnValidate()
    {
        if(_target == null)
            throw new ArgumentNullException(nameof(_target));
    }

    private void Update()
    {
        float distance = Vector3.Distance(_transform.position, _target.position);

        if (distance > _minDistance)
        {
            _moveDirection = (_target.position - transform.position).normalized;
            _rigidbody.velocity = _moveDirection * _speed;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }

        transform.LookAt(_target);
        _rigidbody.velocity += Physics.gravity * _gravity * Time.deltaTime;
    }
}
