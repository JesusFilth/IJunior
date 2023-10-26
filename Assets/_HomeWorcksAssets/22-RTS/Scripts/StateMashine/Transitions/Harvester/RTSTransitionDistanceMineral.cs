using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTSTransitionDistanceMineral : RTSTransition
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RTSMineral mineral))
        {
            NeedTransit = true;
        }
    }
}
