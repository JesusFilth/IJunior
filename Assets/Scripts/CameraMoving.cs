using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _pathRoot;
    [SerializeField] private float _speedCameraMoving = 2;
    [SerializeField]private bool isMoveCamera = true;

    private Transform[] _points;

    private int _currentPoint;
    private void Start()
    {
        _points = new Transform[_pathRoot.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _pathRoot.GetChild(i);
        }

        _currentPoint = 0;
    }

    private void Update()
    {
        if (isMoveCamera == false)
            return;

        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speedCameraMoving*Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                isMoveCamera = false;
        }
    }
}
