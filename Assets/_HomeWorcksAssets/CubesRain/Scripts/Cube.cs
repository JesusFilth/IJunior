using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private const float MinLafetime = 2;
    private const float MaxLifetime = 5;

    private const byte MinColorRange = 0;
    private const byte MaxColorRange = 255;

    public event Action<Cube> Hided;

    private Color32 _defaultColor = new Color32(255, 255, 255, 255);
    private Renderer _renderer;
    private bool _isColorChanged;

    private IEnumerator _hiding;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(GetRandomLifetime());

        if (_hiding == null)
        {
            _hiding = Hiding();
            StartCoroutine(_hiding);
        }
    }

    private void OnDisable()
    {
        if (_hiding != null)
        {
            StopCoroutine(_hiding);
            _hiding = null;
        }
    }

    public void Init()
    {
        _isColorChanged = false;
        SetDefaultColor();
    }

    public void GenerateRandomColor()
    {
        if (_isColorChanged)
            return;

        byte red = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);
        byte green = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);
        byte blue = (byte)UnityEngine.Random.Range(MinColorRange, MaxColorRange);

        Color32 color = new Color32(red, green, blue, MaxColorRange);
        _renderer.material.color = color;

        _isColorChanged = true;
    }

    private void SetDefaultColor()
    {
        _renderer.material.color = _defaultColor;
    }

    private float GetRandomLifetime()
    {
        return UnityEngine.Random.Range(MinLafetime, MaxLifetime +1);
    }

    private IEnumerator Hiding()
    {
        yield return _waitForSeconds;
        Hided?.Invoke(this);

        _hiding = null;
    }
}
