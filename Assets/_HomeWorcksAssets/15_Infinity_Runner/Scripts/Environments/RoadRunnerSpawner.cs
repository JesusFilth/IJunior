using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRunnerSpawner : Pool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capasity;

    [SerializeField] private Vector3 _startFirstModelPosition;
    [SerializeField] private Vector3 _startSpawnModelPosition;

    private void OnEnable()
    {
        Initialize();
    }

    private void Start()
    {
        if (TryGetObject(out GameObject obj))
            CreateObject(obj, _startFirstModelPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RoadRunnerMovement road))
        {
            if (TryGetRandomObject(out GameObject obj))
                CreateObject(obj, _startSpawnModelPosition);
        }
    }

    protected override void Initialize()
    {
        if (_prefab == null)
            return;

        Transform parent = transform;

        if (Ñonteiner != null)
            parent = Ñonteiner;

        for (int i = 0; i < _capasity; i++)
        {
            GameObject temp = Instantiate(_prefab, parent);
            temp.SetActive(false);
            Objects.Add(temp);
        }
    }
}
