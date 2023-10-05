using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRunnerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
