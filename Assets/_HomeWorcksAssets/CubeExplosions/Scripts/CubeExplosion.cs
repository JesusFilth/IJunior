using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeExplosion : MonoBehaviour
{
    private const int MaxPercent = 100;

    private const byte MinColorRange = 0;
    private const byte MaxColorRange = 255;

    [SerializeField] private int _minSeparationCount = 2;
    [SerializeField] private int _maxSeporationCount = 6;

    [SerializeField] private float _explosionForce = 200;
    [SerializeField] private float _explosionRadius = 10;

    private float _separationChance = 100;
    private float _decreaseChance = 2;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();   
    }

    private void OnValidate()
    {
        const int MinBorderMinSeparationCount = 1;
        const int MinBorderMaxSeparationCount = 2;

        if (_minSeparationCount >= _maxSeporationCount)
            _minSeparationCount = _maxSeporationCount-1;

        if (_maxSeporationCount <= _minSeparationCount)
            _maxSeporationCount = _minSeparationCount + 1;

        _minSeparationCount = Mathf.Clamp(_minSeparationCount, MinBorderMinSeparationCount, int.MaxValue);
        _maxSeporationCount = Mathf.Clamp(_maxSeporationCount, MinBorderMaxSeparationCount, int.MaxValue);
    }

    private void OnMouseDown()
    {
        if(CanSeparation())
        {
            int randomNewObjectCount = Random.Range(_minSeparationCount, _maxSeporationCount + 1);

            for (int i = 0; i < randomNewObjectCount; i++)
            {
                CubeExplosion cube = Instantiate(this);
                cube.Init(_separationChance / _decreaseChance);

                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
        else
        {
            Explode();
        }

        Destroy(gameObject);
    }

    public void Init(float seporationChance)
    {
        _separationChance = seporationChance;
        SetRandomColor();
        GenerateModifiedScale();
    }

    private void Explode()
    {
        _explosionRadius = GetModifiedRadius();
        _explosionForce =  GetModifiedForce();

        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            float force = GetForceFromDistanceObject(explodableObject.transform);
            explodableObject.AddExplosionForce(force, transform.position, _explosionRadius, 1f, ForceMode.Impulse);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> objects = new List<Rigidbody>();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);
        }

        return objects;
    }

    private float GetForceFromDistanceObject(Transform objectPosition)
    {
        float distance = Vector3.Distance(transform.position, objectPosition.position);
        return  _explosionForce * (1f - distance / _explosionRadius);
    }

    private bool CanSeparation()
    {
        float chance = Random.Range(0, MaxPercent);

        return chance <= _separationChance;
    }

    private void SetRandomColor()
    {
        byte red = (byte)Random.Range(MinColorRange, MaxColorRange);
        byte green = (byte)Random.Range(MinColorRange, MaxColorRange);
        byte blue = (byte)Random.Range(MinColorRange, MaxColorRange);

        Color32 color = new Color32(red,green,blue, MaxColorRange);

        _renderer.material.color = color;
    }

    private void GenerateModifiedScale()
    {
        float valueScale = _separationChance / MaxPercent;

        Vector3 scale = new Vector3(valueScale, valueScale, valueScale);
        transform.localScale = scale;
    }

    private float GetModifiedRadius()
    {
        return (MaxPercent / _separationChance) * _explosionRadius;
    }

    private float GetModifiedForce()
    {
        return (MaxPercent / _separationChance) * _explosionForce;
    }
}
