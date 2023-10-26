using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class SpawnModel
{
    [SerializeField] private UnityEngine.GameObject _prefab;
    [Range(0, 100)]
    [SerializeField] private float _weight = 1.0f;

    public float Weight => _weight;
    public UnityEngine.GameObject Prefab => _prefab;
}
