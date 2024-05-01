using System;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeValue;
    }

    private void OnValidate()
    {
        if (_text == null)
            throw new ArgumentNullException(nameof(_text));

        if (_counter == null)
            throw new ArgumentNullException(nameof(_counter));
    }

    private void ChangeValue(int value)
    {
        _text.text = value.ToString();
    }
}
