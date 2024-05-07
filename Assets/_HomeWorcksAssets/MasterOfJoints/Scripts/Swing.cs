using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _force = 10f;
    [SerializeField] private KeyCode _left = KeyCode.Mouse0;
    [SerializeField] private KeyCode _right = KeyCode.Mouse1;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(_left))
        {
            AddForce(Vector3.left);
        }
        else if (Input.GetKey(_right))
        {
            AddForce(Vector3.right);
        }
    }

    private void AddForce(Vector3 dictionary)
    {
        _rigidbody.AddForce(dictionary * _force, ForceMode.Impulse);
    }
}
