using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private bool _isActive = true;

    private SpawnPoint[] _points;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_time);

        if (_isActive)
            StartCoroutine(CreateEnemy());
    }

    private void OnEnable()
    {
        _points = new SpawnPoint[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i).GetComponent<SpawnPoint>();
        }
    }

    private IEnumerator CreateEnemy()
    {
        while (_isActive)
        {
            yield return _waitForSeconds;

            SpawnPoint point = _points[Random.Range(0, _points.Length)];
            point.CreateEnemy();
        }
    }
}
