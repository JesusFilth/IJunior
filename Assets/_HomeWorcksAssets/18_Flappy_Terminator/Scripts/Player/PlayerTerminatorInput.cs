using UnityEngine;

[RequireComponent(typeof(PlayerTerminatorMovement))]
[RequireComponent(typeof(PlayerTerminatorAttack))]
public class PlayerTerminatorInput : MonoBehaviour
{
    private PlayerTerminatorMovement _playerMovement;
    private PlayerTerminatorAttack _playerAttack;

    private void OnEnable()
    {
        _playerMovement = GetComponent<PlayerTerminatorMovement>();
        _playerAttack = GetComponent<PlayerTerminatorAttack>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _playerMovement.AddForce();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _playerAttack.Shot();
        }
    }
}
