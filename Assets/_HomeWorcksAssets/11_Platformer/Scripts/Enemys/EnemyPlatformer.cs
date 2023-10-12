using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformer : MonoBehaviour
{
    [SerializeField] private PlayerPlatformer _playerTarget;
    [SerializeField] private int _health = 3;

    public PlayerPlatformer PlayerTarget => _playerTarget;

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health-damage,0,int.MaxValue);
    }

    public bool IsDead()
    {
        return _health == 0;
    }
}
