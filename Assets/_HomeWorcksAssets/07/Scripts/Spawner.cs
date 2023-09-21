using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private bool _isActive = true;

    private SpawnPoint[] _points;

    private void Start()
    {
        if(_isActive)
            StartCoroutine(CreateEnemy(_time));
    }

    private void OnEnable()
    {
        _points = new SpawnPoint[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i).GetComponent<SpawnPoint>();
        }
    }

    private IEnumerator CreateEnemy(float waitTime)
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(waitTime);

            SpawnPoint point = _points[Random.Range(0, _points.Length)].GetComponent<SpawnPoint>();
            point.CreateEnemy();
        }
    }
}
