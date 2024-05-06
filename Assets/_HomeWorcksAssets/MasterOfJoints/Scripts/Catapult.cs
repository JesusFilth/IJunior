using System.Collections;
using System;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private GameObject _corePrefab;
    [SerializeField] private Transform _startPointCore;

    [SerializeField] private SpringJoint _dawnSpring;
    [SerializeField] private SpringJoint _upSpring;

    [SerializeField] private Rigidbody _spoon;

    [SerializeField] private float _minSpringForce = 0;
    [SerializeField] private float _maxSpringForce = 100;

    [SerializeField] private float _timeStartPosition = 2f;

    private float _currentTime;

    private IEnumerator _starting;
    private bool _canShoot;

    private void OnValidate()
    {
        if (_corePrefab == null)
            throw new ArgumentNullException(nameof(_corePrefab));

        if (_dawnSpring == null)
            throw new ArgumentNullException(nameof(_dawnSpring));

        if (_upSpring == null)
            throw new ArgumentNullException(nameof(_upSpring));

        if (_spoon == null)
            throw new ArgumentNullException(nameof(_spoon));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ResetSpoon();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Shoot();
        }    
    }

    private void OnDisable()
    {
        if(_starting != null)
        {
            StopCoroutine(_starting);
            _starting = null;
        }
    }

    private void ResetSpoon()
    {
        _upSpring.spring = 0;

        if(_starting == null)
        {
            _starting = Starting();
            StartCoroutine(_starting);
        }
    }

    private void Shoot()
    {
        if (_canShoot == false)
            return;

        _dawnSpring.spring = _minSpringForce;
        _upSpring.spring = _maxSpringForce;

        _spoon.AddForce(Vector3.up, ForceMode.Impulse);
    }

    private void CreateCore()
    {
        GameObject core = Instantiate(_corePrefab);
        core.transform.position = _startPointCore.position;
    }

    private IEnumerator Starting()
    {
        _currentTime = 0;

        while (_currentTime <= _timeStartPosition && enabled)
        {
            _currentTime += Time.deltaTime;
            float step = _currentTime / _timeStartPosition;

            _dawnSpring.spring = Mathf.Lerp(_minSpringForce, _maxSpringForce, step);

            yield return null;
        }

        CreateCore();

        _dawnSpring.spring = _maxSpringForce;
        _canShoot = true;
        _starting = null;
    }
}