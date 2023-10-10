using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTerminatorMovement : MonoBehaviour
{
    [SerializeField] private float _tapForce = 100f;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private Vector3 _startPosition;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector3.zero;

        transform.position = _startPosition;

        _minRotation = Quaternion.Euler(0,0,_minRotationZ);
        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
    }

    private void Update()
    {
        Rotate();
    }

    public void AddForce()
    {
        _rigidbody.velocity = new Vector2(_speed,0);
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        transform.rotation = _maxRotation;
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
