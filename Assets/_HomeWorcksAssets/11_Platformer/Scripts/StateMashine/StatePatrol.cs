using UnityEngine;

[RequireComponent(typeof(Animator))]
class StatePatrol : State
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceForNextPoint = 0.5f;

    private int _currentIndex = 0;
    private Animator _animator;

    private void OnEnable()
    {
        if(_animator==null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(AnimationData.Params.IsWalk, true);

        ChengeRotationY();
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimationData.Params.IsWalk, false);
    }

    private void Update()
    {
        if (_points.Length == 0)
            return;

        Move();
    }

    private void Move()
    {
        Vector3 newPosition = new Vector3(_points[_currentIndex].position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _points[_currentIndex].position) <= _distanceForNextPoint)
        {
            _currentIndex++;

            if (_currentIndex >= _points.Length)
                _currentIndex = 0;

            ChengeRotationY();
        }
    }

    private void ChengeRotationY()
    {
        const float AngleRotation = 180f;

        Vector3 direction = _points[_currentIndex].position - transform.position;
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
