using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffects: MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private FXEffect _damage;
    [SerializeField] private FXEffect _heal;

    public void Hit()
    {
        Instantiate(_damage, _target);
    }

    public void Heal()
    {
        Instantiate(_heal, _target);
    }
}
