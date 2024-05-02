using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeRain _prefab;

    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private int _poolCapasity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    [SerializeField] private float _startHeight = 5;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out CubeRain cube))
            cube.GenerateRandomColor();
    }

    private void Create()
    {
        _pool.Get();
    }

    private void ActionOnGet(CubeRain cube)
    {
        cube.transform.position = GetStartRandomPosition();
        cube.Init();
        cube.gameObject.SetActive(true);

        cube.Hided += ActionOnRelease;
    }

    private void ActionOnRelease(CubeRain cube) 
    {
        cube.Hided -= ActionOnRelease;

        _pool.Release(cube);
    }

    private Vector3 GetStartRandomPosition()
    {
        const float HalfSize = 2f;

        Vector3 platformCenter = transform.position;
        Vector3 platformSize = transform.localScale;

        float randomX = Random.Range(platformCenter.x - platformSize.x / HalfSize, platformCenter.x + platformSize.x / HalfSize);
        float randomZ = Random.Range(platformCenter.z - platformSize.z / HalfSize, platformCenter.z + platformSize.z / HalfSize);

        float height = platformCenter.y + _startHeight;

        return new Vector3(randomX, height, randomZ);
    }
}
