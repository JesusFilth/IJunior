using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VampireSpellButtonView : MonoBehaviour
{
    [SerializeField] private VampireSpell _spell;
    [SerializeField] private TMP_Text _buttonText;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonText.text = _spell.ButtonForActive.ToString();
    }

    private void OnValidate()
    {
        if (_spell == null)
            throw new ArgumentNullException(nameof(_spell));

        if (_buttonText == null)
            throw new ArgumentNullException(nameof(_buttonText));
    }

    private void Update()
    {
        _button.interactable = _spell.IsActive;
    }
}
