using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatTerminatorDisplay : MonoBehaviour
{
    const string HealthText = "Health: ";
    const string PointText = "Point: ";

    [SerializeField] private PlayerTerminator _player;
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
        _points.text = $"{PointText}{points}";
    }

    private void ChangeHealth(int health)
    {
        _health.text = $"{HealthText}{health}";
    }
}
