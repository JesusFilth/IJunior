using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBird : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _timeSecondDistance = 3;
    [SerializeField] private bool _rightDirection = true;

    private SpriteRenderer _spriteRenderer;
    private IEnumerator _changingDirection;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = !_rightDirection;

        if (_changingDirection == null)
        {
            _changingDirection = Moving();
            StartCoroutine(_changingDirection);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate((_rightDirection ? transform.right : -transform.right)
            * _speed * Time.deltaTime);
    }

    private IEnumerator Moving()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeSecondDistance);

        while (enabled)
        {
            yield return waitForSeconds;

            _rightDirection = !_rightDirection;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        _changingDirection = null;
    }
}
