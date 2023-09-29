using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEffects: MonoBehaviour
{
    [SerializeField] Transform _target;

    [SerializeField] FXEffect _damage;
    [SerializeField] FXEffect _heal;

    public void Hit()
    {
        Instantiate(_damage, _target);
    }

    public void Heal()
    {
        Instantiate(_heal, _target);
    }
}
