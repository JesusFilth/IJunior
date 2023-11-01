using UnityEngine;

public class RTSTransitionHarvesterDistanceMineral : RTSTransition
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RTSMineral mineral))
        {
            NeedTransit = true;
        }
    }
}
