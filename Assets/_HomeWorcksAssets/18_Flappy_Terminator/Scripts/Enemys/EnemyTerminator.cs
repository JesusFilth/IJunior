using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerminator : MonoBehaviour
{
    [SerializeField] private int _damage;

    private PlayerTerminator _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerTerminator player))
            player.TakeDamage(_damage);

        gameObject.SetActive(false);
    }

    public void Die()
    {
        if (_player != null)
            _player.AddPoint();

        gameObject.SetActive(false);
    }

    public void Init(PlayerTerminator player)
    {
        _player = player;
    }
}
