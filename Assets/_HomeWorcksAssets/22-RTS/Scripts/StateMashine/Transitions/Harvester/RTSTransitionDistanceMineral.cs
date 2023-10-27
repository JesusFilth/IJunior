using UnityEngine;

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
