using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Thief : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis(HorizontalInput);
        float verticalInput = Input.GetAxis(VerticalInput);

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (direction != Vector3.zero)
        {
            _rigidbody.velocity = direction * _speed;
            _animator.SetBool(AnimatorData.Params.IsWalk, true);

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360f * Time.deltaTime);
        }
        else
        {
            _animator.SetBool(AnimatorData.Params.IsWalk, false);
        }
    }

    public class AnimatorData
    {
        public class Params
        {
            public static int IsWalk = Animator.StringToHash(nameof(IsWalk));
        }
    }
}