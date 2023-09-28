using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fly : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _timeSecondDistance = 3;
    [SerializeField] private bool _rightDirection = true;
    

    private float _currentTime = 0;
    private SpriteRenderer _spriteRenderer;
    
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = !_rightDirection;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = Vector3.zero;

        if (_rightDirection)
            direction = transform.right;
        else
            direction = -transform.right;

        transform.Translate(direction * _speed * Time.deltaTime);
        _currentTime += Time.deltaTime;

        if (_currentTime > _timeSecondDistance)
        {
            _rightDirection = !_rightDirection;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _currentTime = 0;
        }
    }
}
