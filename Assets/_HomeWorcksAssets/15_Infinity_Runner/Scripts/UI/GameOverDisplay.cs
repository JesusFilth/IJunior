using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] private PlayerRunner _player;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _repeat;
    [SerializeField] private TMP_Text _totalPoints;

    [SerializeField] private UnityEvent _onShow;

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();

        if (_exit != null)
            _exit.onClick.AddListener(OnExit);

        if (_repeat != null)
            _repeat.onClick.AddListener(OnRepeat);

        if (_player == null)
            return;

        _player.Died += Show;
        _player.PointChanged += ChangePoint;
    }

    private void OnDisable()
    {
        if (_exit != null)
            _exit.onClick.RemoveListener(OnExit);

        if (_repeat != null)
            _repeat.onClick.RemoveListener(OnRepeat);

        if (_player != null)
            return;

        _player.Died -= Show;
        _player.PointChanged -= ChangePoint;
    }

    private void Show()
    {
        _onShow?.Invoke();
        _animator.SetBool(AnimationsDate.Params.IsShow,true);
        Time.timeScale = 0;
    }

    private void ChangePoint(int point)
    {
        _totalPoints.text = point.ToString();
    }

    private void OnExit()
    {
        Application.Quit();
    }

    private void OnRepeat()
    {
        Time.timeScale = 1;
        homework_15_runner.Load();
    }

    private class AnimationsDate
    {
        public class Params
        {
            public static int IsShow = Animator.StringToHash(nameof(IsShow));
        }
    }
}
