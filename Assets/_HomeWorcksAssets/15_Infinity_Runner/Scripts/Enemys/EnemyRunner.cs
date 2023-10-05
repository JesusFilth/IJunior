using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunner : ObjectRunner
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent(out PlayerRunner player))
        {
            player.ChangeHealth(-_damage);
            Die();
        }
    }
}
