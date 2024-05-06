using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _force = 10f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(Vector3.left * _force, ForceMode.Impulse);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _rigidbody.AddForce(Vector3.right * _force, ForceMode.Impulse);
        }
    }
}
