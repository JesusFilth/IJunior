using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateFollowPlayer : State
{
    [SerializeField] private float _speed = 3;

    private Animator _animator;

    private void OnEnable()
    {
        if(_animator==null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(AnimationData.Params.IsRun, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimationData.Params.IsRun, false);
    }

    private void Update()
    {
        Move();
        ChengeRotationY();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerTarget.transform.position, _speed * Time.deltaTime);
    }

    private void ChengeRotationY()
    {
        const float AngleRotation = 180f;

        Vector3 direction = PlayerTarget.transform.position - transform.position;
        Quaternion targetRotation;

        if (direction.x < 0 && transform.rotation.y != AngleRotation)
        {
            targetRotation = Quaternion.Euler(new Vector3(0, AngleRotation, 0));
            transform.rotation = targetRotation;
        }
        else if (direction.x > 0 && transform.rotation.y != 0)
        {
            targetRotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = targetRotation;
        }
    }
}
