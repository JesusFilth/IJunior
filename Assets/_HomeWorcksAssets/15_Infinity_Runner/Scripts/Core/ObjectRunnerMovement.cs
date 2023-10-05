using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRunnerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
