using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _magnitude = 0.2f;

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private Transform _transform;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _transform = transform;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);

        _moveDirection = new Vector3(horizontal, 0, vertical);

        if (_moveDirection.magnitude >= _magnitude)
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        _moveDirection.y -= _gravity * _speed;
        _controller.Move(_moveDirection * _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float targetAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
