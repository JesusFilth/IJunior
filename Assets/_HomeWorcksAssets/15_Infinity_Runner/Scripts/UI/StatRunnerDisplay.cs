using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatRunnerDisplay : MonoBehaviour
{
    [SerializeField] private PlayerRunner _player;
    [Space]
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _points;

    private void OnEnable()
    {
        if (_player == null)
            return;

        _player.HealthChanged += ChangeHealth;
        _player.PointChanged += ChangePoints;
    }

    private void OnDisable()
    {
        if (_player == null)
            return;

        _player.HealthChanged -= ChangeHealth;
        _player.PointChanged -= ChangePoints;
    }

    private void ChangePoints(int points)
    {
        _points.text = points.ToString();
    }

    private void ChangeHealth(int health, bool isHealthUp, bool isIgnore)
    {
        _health.text = health.ToString();
    }
}
