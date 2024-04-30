using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    public event Action<int> ValueChanged;

    private int _value = 0;
    private IEnumerator _processing;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        ValueChanged?.Invoke(_value);
    }

    private void OnDisable()
    {
        if (_processing != null)
        {
            StopCoroutine(_processing);
            _processing = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_processing == null)
            {
                _processing = Pricessing();
                StartCoroutine(_processing);
            }
            else
            {
                StopCoroutine(_processing);
                _processing = null;
            }
        }
    }

    private IEnumerator Pricessing()
    {
        while (enabled)
        {
            yield return _waitForSeconds;

            _value++;
            ValueChanged?.Invoke(_value);
        }
    }
}
