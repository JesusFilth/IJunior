using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSHarvester))]
public class RTSTransitionMineralCollection : RTSTransition
{
    private RTSHarvester _harvester;

    private float _currentTime = 0f;

    private void Start()
    {
        _harvester = GetComponent<RTSHarvester>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _harvester.CollectionTime)
        {
            _harvester.RecycleMineral();
            _currentTime = 0f;
            NeedTransit = true;
        }
    }
}
