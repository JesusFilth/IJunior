using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class SpawnModel
{
    [SerializeField] private GameObject _prefab;
    [Range(0, 100)]
    [SerializeField] private float _weight = 1.0f;

    public float Weight => _weight;
    public GameObject Prefab => _prefab;
}
