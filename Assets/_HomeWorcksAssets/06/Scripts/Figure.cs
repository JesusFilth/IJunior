using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _speedScale;

    [SerializeField] private bool _isMove;
    [SerializeField] private bool _isRotate;
    [SerializeField] private bool _isScale;

    private void Update()
    {
        if (_isMove)
            Move();

        if (_isRotate)
            Rotate();

        if (_isScale)
            Scale();
    }

    private void Move()
    {
        transform.Translate(transform.forward * _speedMove * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(0, _speedRotate * Time.deltaTime, 0);
    }

    private void Scale()
    {
        transform.localScale = transform.localScale + (Vector3.one * _speedScale * Time.deltaTime);
    }
}
