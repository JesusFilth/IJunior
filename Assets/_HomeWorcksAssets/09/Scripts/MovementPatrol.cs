using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _rootPoints;

    private Transform[] _points;
    private int _currentPointIndex = 0;

    private void OnEnable()
    {
        _points = new Transform[_rootPoints.childCount];

        for (int i = 0; i < _rootPoints.childCount; i++)
            _points[i] = _rootPoints.GetChild(i).GetComponent<Transform>();

        RotateToCurrentPoint();
    }

    private void Update()
    {
        Transform currentPoint = _points[_currentPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
            NextPoint();
    }

    private void NextPoint()
    {
        _currentPointIndex++;

        if (_currentPointIndex >= _points.Length)
            _currentPointIndex = 0;

        RotateToCurrentPoint();
    }

    private void RotateToCurrentPoint()
    {
        Vector3 direction = (_points[_currentPointIndex].transform.position - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}