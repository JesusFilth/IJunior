using System.Collections;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(RTSHarvester))]
[RequireComponent(typeof(NavMeshAgent))]
public class RTSStateHarvesterMoveToMineral : RTSState
{
    private RTSHarvester _harvester;
    private NavMeshAgent _agent;

    private void Start()
    {
        _harvester = GetComponent<RTSHarvester>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_harvester.CurrentMineral.transform.position);
    }

    private void OnDisable()
    {
        _agent.ResetPath();
    }
}
