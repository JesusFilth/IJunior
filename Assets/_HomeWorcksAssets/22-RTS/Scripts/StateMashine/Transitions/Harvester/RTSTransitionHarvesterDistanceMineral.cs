using UnityEngine;

[RequireComponent(typeof(RTSHarvester))]
public class RTSTransitionHarvesterDistanceMineral : RTSTransition
{
    [SerializeField] float _distance = 1;

    private RTSHarvester _harvester;

    private void Start()
    {
        _harvester = GetComponent<RTSHarvester>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _harvester.CurrentMineral.transform.position) <= _distance)
        {
            NeedTransit = true;
        }
    }
}
