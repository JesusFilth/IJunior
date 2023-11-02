using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RTS
{
    public class RTSUIProduct : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        private UnityEvent _action;

        private void OnEnable()
        {
            _button.onClick.AddListener(ActiveAction);
        }

        private void OnDisable()
        {
            _button.onClick?.RemoveListener(ActiveAction);
        }

        public void Init(string name, string price, Sprite icon, UnityEvent action)
        {
            _name.text = name;
            _price.text = price;
            _icon.sprite = icon;
            _action = action;
        }

        private void ActiveAction()
        {
            _action?.Invoke();
        }
    }
}
