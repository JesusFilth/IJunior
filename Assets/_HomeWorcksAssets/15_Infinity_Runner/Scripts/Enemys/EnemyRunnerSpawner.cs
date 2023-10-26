using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRunnerSpawner : Pool
{
    [SerializeField] private SpawnModel[] _spawnModels;
    [Space] [SerializeField] private int _capasity;
    [Space] [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay = 3;
    [SerializeField] private float _minDelay = 0.1f;

    private IEnumerator _creating;

    private void OnEnable()
    {
        Initialize();

        if (_creating == null)
            _creating = Creating();
    }

    private void Start()
    {
        StartCoroutine(_creating);
    }

    private void OnDisable()
    {
        if (_creating != null)
        {
            StopCoroutine(_creating);
            _creating = null;
        }
    }

    public void AddDelay(float value)
    {
        _delay = Mathf.Clamp(_delay += value, _minDelay, float.MaxValue);

        if (_creating != null)
            StopCoroutine(_creating);

        _creating = Creating();
        StartCoroutine(_creating);
    }

    protected override void Initialize()
    {
        if (_spawnModels == null || _spawnModels.Length == 0)
        {
            Debug.Log("No enemy prefabs assigned");
            return;
        }

        if (_points == null || _points.Length == 0)
        {
            Debug.Log("No spawn points assigned");
            return;
        }

        Transform parent = transform;

        if (Conteiner != null)
            parent = Conteiner;

        float totalWeight = _spawnModels.Sum(spawnModel => spawnModel.Weight);
        Dictionary<UnityEngine.GameObject, int> countCreatObject = new Dictionary<UnityEngine.GameObject, int>();

        foreach (var spawnModel in _spawnModels)
        {
            int count = (int)Mathf.Round(spawnModel.Weight / totalWeight * _capasity);
            countCreatObject.Add(spawnModel.Prefab, count);
        }

        foreach (var objCreate in countCreatObject)
        {
            for (int i = 0; i < objCreate.Value; i++)
            {
                UnityEngine.GameObject temp = Instantiate(objCreate.Key, parent);
                temp.SetActive(false);
                Objects.Add(temp);
            }
        }
    }

    private IEnumerator Creating()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            if (TryGetRandomObject(out UnityEngine.GameObject enemy))
            {
                base.CreateObject(enemy, _points[Random.Range(0, _points.Length)].position);
            }

            yield return waitForSeconds;
        }

        _creating = null;
    }
}
