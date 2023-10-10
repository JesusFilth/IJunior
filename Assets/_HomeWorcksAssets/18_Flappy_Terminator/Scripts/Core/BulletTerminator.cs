using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTerminator : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerTerminator player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent(out EnemyTerminator enemy))
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
}
