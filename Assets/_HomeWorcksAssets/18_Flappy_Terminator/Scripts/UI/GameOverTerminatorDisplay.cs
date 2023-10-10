using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverTerminatorDisplay : MonoBehaviour
{
    [SerializeField] private PlayerTerminator _player;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _repeat;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        if (_exit != null)
            _exit.onClick.AddListener(OnExit);

        if (_repeat != null)
            _repeat.onClick.AddListener(OnRepeat);

        if (_player == null)
            return;

        _player.Died += Show;
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
    }

    private void Show()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
    }

    private void OnExit()
    {
        Application.Quit();
    }

    private void OnRepeat()
    {
        Time.timeScale = 1;
        homework_18_Flappy_Terminator.Load();
    }
}
