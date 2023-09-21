using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speedEnemy;
    [SerializeField] private EnemyTarget _enemyTarget;

    public void CreateEnemy()
    {
        Enemy tempEnemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        tempEnemy.Init(_enemyTarget, _speedEnemy);
    }
}
