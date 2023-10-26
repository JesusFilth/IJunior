using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysTerminatorSpawner : Pool
{
    [SerializeField] private EnemyTerminator _prefab;
    [SerializeField] private int _capasity;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private PlayerTerminator _player;

    private IEnumerator _creating;

    private void OnEnable()
    {
        Initialize();

        if (_creating == null)
            _creating = Creating();
    }

    private void OnDisable()
    {
        if(_creating!=null)
        {
            StopCoroutine(_creating);
            _creating = null;
        }    
    }

    private void Start()
    {
        if (Objects.Count == 0)
            return;

        if (_points.Length == 0)
            return;

        StartCoroutine(_creating);
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
            EnemyTerminator temp = Instantiate(_prefab, parent);
            temp.gameObject.SetActive(false);
            temp.Init(_player);
            Objects.Add(temp.gameObject);
        }
    }

    private IEnumerator Creating()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            if(TryGetObject(out UnityEngine.GameObject obj))
                base.CreateObject(obj, _points[Random.Range(0, _points.Length)].position);

            yield return waitForSeconds;
        }

        _creating = null;
    }
}
