using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowTarggetUI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetY;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch(Exception ex)
        {
            enabled = false;
            throw ex;
        }
    }

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 targetPosition = _target.position;
        targetPosition.y += _offsetY;

        transform.position = targetPosition;
    }

    private void Validate()
    {
       if(_target == null)
            throw new ArgumentNullException(nameof(_target));  
    }
}
