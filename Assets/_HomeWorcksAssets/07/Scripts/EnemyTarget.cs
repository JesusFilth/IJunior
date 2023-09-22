using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private float _angle = 0f;

    private void Update()
    {
        float x = Mathf.Cos(_angle) * _radius;
        float y = transform.position.y;
        float z = Mathf.Sin(_angle) * _radius;

        transform.position = new Vector3(x, y, z);

        _angle += _speed * Time.deltaTime;

        float round = 2f;

        if (_angle >= round * Mathf.PI)
        {
            _angle -= round * Mathf.PI;
        }
    }
}
