using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSHarvester))]
public class RTSStateMineralCollection : RTSState
{
    private RTSHarvester _harvester;
    private bool _isProcess = false;

    private void Start()
    {
        _harvester = GetComponent<RTSHarvester>();
    }

    private void Update()
    {
        if (_isProcess == false)
        {
            _isProcess = true;
            _harvester.CollectionProcessOn();
        }
    }

    private void OnDisable()
    {
        _harvester.CollectionProcessOff();
        _isProcess = false;
    }
}
