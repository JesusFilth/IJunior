using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRunnerMovement))]
public class PlayerRunnerInput : MonoBehaviour
{
    private PlayerRunnerMovement _movement;

    private void OnEnable()
    {
        _movement = GetComponent<PlayerRunnerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _movement.TryLeftStep();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _movement.TryRightStep();
        }
    }
}
