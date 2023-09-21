using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speedEnemy;
    private EnemyTarget _target;

    private void Update()
    {
        if (_target == null)
            return;

        transform.LookAt(_target.transform);

        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speedEnemy * Time.deltaTime);
    }

    public void Init(EnemyTarget target, float speedEnemy)
    {
        _speedEnemy = speedEnemy;
        _target = target;
    }
}
