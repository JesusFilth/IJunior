using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointRunner : ObjectRunner
{
    [SerializeField] private int _point;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerRunner player))
        {
            player.AddPoint(_point);
            Die();
        }
    }
}
