using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speedEnemy;
    private Vector3 _moveDirection = Vector3.zero;

    private void Update()
    {
        if (_moveDirection == Vector3.zero)
            return;

        transform.Translate(transform.forward * _speedEnemy * Time.deltaTime, Space.World);
    }

    public void Init(Vector3 direction, float speedEnemy)
    {
        _speedEnemy = speedEnemy;
        _moveDirection = (direction - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(_moveDirection);
    }
}
