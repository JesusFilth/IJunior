using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidSpawner : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _positionY;

    [SerializeField] private Aid _prefab;
    [SerializeField] private int _count;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            float positionX = Random.Range(_startPoint.position.x, _endPoint.position.x+1);
            Vector3 spawnPoint = new Vector3(positionX, _positionY.position.y, 0);

            Instantiate(_prefab, spawnPoint, Quaternion.identity);
        }
    }
}
