using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSHarvester))]
public class RTSTransitionHarvesterFindMineral : RTSTransition
{
    private RTSHarvester _harvester;

    private void Start()
    {
        _harvester = GetComponent<RTSHarvester>();
    }

    private void Update()
    {
        if (_harvester.GetMineralConteiner() == null)
            return;

        if (TryGetActives(out List<GameObject> activeMinerals))
        {
            GameObject nearMineral = FindNearest(activeMinerals);

            if (nearMineral == null)
                return;

            if (_harvester.IsHasCurrentMineral())
            {
                if (nearMineral == _harvester.CurrentMineral.gameObject)
                    return;
            }

            if (nearMineral.TryGetComponent(out RTSMineral mineral))
            {
                _harvester.SetCurrentMineral(mineral);
                NeedTransit = true;
            }
        }
    }

    private bool TryGetActives(out List<GameObject> activeMinerals)
    {
        activeMinerals = new List<GameObject>();
        Transform minerals = _harvester.GetMineralConteiner();

        if (minerals == null)
            return false;

        for (int i = 0; i < minerals.childCount; i++)
        {
            if (minerals.GetChild(i).gameObject.activeSelf)
                activeMinerals.Add(minerals.GetChild(i).gameObject);
        }

        if (activeMinerals.Count != 0)
            return true;

        return false;
    }

    private GameObject FindNearest(List<GameObject> activeMinerals)
    {
        if (activeMinerals == null || activeMinerals.Count == 0)
            return null;

        GameObject nearObject = null;

        float nearDistance;
        float currentNearDistance;

        if (_harvester.IsHasCurrentMineral())
        {
            nearObject = _harvester.CurrentMineral.gameObject;
            nearDistance = Vector3.Distance(transform.position, nearObject.transform.position);
        }
        else
        {
            nearDistance = Vector3.Distance(transform.position, activeMinerals[0].transform.position);
        }

        foreach (var mineral in activeMinerals)
        {
            currentNearDistance = Vector3.Distance(transform.position, mineral.transform.position);

            if (currentNearDistance <= nearDistance)
            {
                nearDistance = currentNearDistance;
                nearObject = mineral;
            }
        }

        return nearObject;
    }
}
