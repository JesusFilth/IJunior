using Assets._HomeWorcksAssets.CubeExplosions.Scripts;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour, IExposion, ISeparation
{
    [SerializeField] [Range(1,100)] private int _minSeparationCount = 2;
    [SerializeField] [Range(2,100)] private int _maxSeporationCount = 6;

    [SerializeField] private float _explosionForce = 200;
    [SerializeField] private float _explosionRadius = 10;

    private float _separationChance = 100;

    private Renderer _renderer;
    private ExplosionObject _explosion;
    private CubeSeparation _separation;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _explosion = new ExplosionObject(this);
        _separation = new CubeSeparation();
    }

    private void OnMouseDown()
    {
        if (_separation.CanDivide(_separationChance))
        {
            int randomNewObjectCount = Random.Range(_minSeparationCount, _maxSeporationCount + 1);

            for (int i = 0; i < randomNewObjectCount; i++)
            {
                Cube cube = Instantiate(this);
                _separation.Divide(cube, _separationChance);

                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    _explosion.ExplodeSimple(rigidbody);
            }
        }
        else
        {
            _explosion.ExplodeModified();
        }

        Destroy(gameObject);
    }

    public Vector3 GetPoint() => transform.position;

    public float GetRadius() => _explosionRadius;

    public float GetForce() => _explosionForce;

    public float GetSeparation() => _separationChance;

    public void SetSeporationChance(float chance) =>_separationChance = chance;

    public void SetColor(Color32 color) => _renderer.material.color = color;

    public void SetScale(Vector3 scale) => transform.localScale = scale;
}
