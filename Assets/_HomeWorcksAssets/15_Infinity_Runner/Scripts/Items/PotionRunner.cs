using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRunner : ObjectRunner
{
    [SerializeField] private int _helth = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerRunner player))
        {
            player.ChangeHealth(_helth);
            Die();
        }
    }
}
