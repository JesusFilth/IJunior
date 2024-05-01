using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private const float MinLafetime = 2;
    private const float MaxLifetime = 5;

    private const byte MinColorRange = 0;
    private const byte MaxColorRange = 255;

    private Color32 _defaultColor = new Color32(255, 255, 255, 255);
    private Renderer _renderer;

    private bool _isColorChanged;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Destroy(gameObject, GetRandomLifetime());
    }

    public void Init()
    {
        _isColorChanged = false;
        Destroy(gameObject, GetRandomLifetime());

        //SetDefaultColor();
    }

    public void GenerateRandomColor()
    {
        if (_isColorChanged)
            return;

        byte red = (byte)Random.Range(MinColorRange, MaxColorRange);
        byte green = (byte)Random.Range(MinColorRange, MaxColorRange);
        byte blue = (byte)Random.Range(MinColorRange, MaxColorRange);

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
        return Random.Range(MinLafetime, MaxLifetime +1);
    }
}
