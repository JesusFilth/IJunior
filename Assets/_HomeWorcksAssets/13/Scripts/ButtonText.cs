using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ButtonText : MonoBehaviour
{
    [SerializeField] private Color _colorEnterPointer;

    private Color _defaultColor;
    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        _defaultColor = _text.color;
    }

    public void ChangeColorPointerEnter()
    {
        _text.color = _colorEnterPointer;
    }

    public void ResetColor()
    {
        _text.color = _defaultColor;
    }
}
