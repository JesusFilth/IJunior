using UnityEngine;
using UnityEngine.Pool;
using System;
using Assets._HomeWorcksAssets.CubesRain.Scripts;

public class CubeRainSpawner : MonoBehaviour
{
    [SerializeField] private CubeRain _prefab;

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    [SerializeField] private RainPlatform _platform;

    private ObjectPool<CubeRain> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<CubeRain>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube)=> ActionOnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube)=> Destroy(cube),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(Create), 0f, _repeatRate);
    }

    private void OnValidate()
    {
        if (_platform == null)
            throw new ArgumentNullException(nameof(_platform));
    }

    private void Create()
    {
        _pool.Get();
    }

    private void ActionOnGet(CubeRain cube)
    {
        cube.transform.position = _platform.GetRandomPosition();
        cube.Init();
        cube.gameObject.SetActive(true);

        cube.Hided += ActionOnRelease;
    }

    private void ActionOnRelease(CubeRain cube) 
    {
        cube.Hided -= ActionOnRelease;

        _pool.Release(cube);
    }
}
