using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRunnerSpawner : Pool
{
    [SerializeField] private UnityEngine.GameObject _prefab;
    [SerializeField] private int _capasity;

    [SerializeField] private Vector3 _startFirstModelPosition;
    [SerializeField] private Vector3 _startSpawnModelPosition;

    private void OnEnable()
    {
        Initialize();
    }

    private void Start()
    {
        if (TryGetObject(out UnityEngine.GameObject obj))
            base.CreateObject(obj, _startFirstModelPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RoadRunnerMovement road))
        {
            if (TryGetRandomObject(out UnityEngine.GameObject obj))
                base.CreateObject(obj, _startSpawnModelPosition);
        }
    }

    protected override void Initialize()
    {
        if (_prefab == null)
            return;

        Transform parent = transform;

        if (Conteiner != null)
            parent = Conteiner;

        for (int i = 0; i < _capasity; i++)
        {
            UnityEngine.GameObject temp = Instantiate(_prefab, parent);
            temp.SetActive(false);
            Objects.Add(temp);
        }
    }
}
