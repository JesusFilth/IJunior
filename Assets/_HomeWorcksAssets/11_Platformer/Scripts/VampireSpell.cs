using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class VampireSpell : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private int _countRays = 36;
    [SerializeField] private float _rayOffsetY = 0.5f;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _secondDuration = 6;
    [SerializeField] private int _secondDelay = 1;
    [SerializeField] private float _damage = 2;

    [SerializeField] private KeyCode _buttonForActive = KeyCode.E;

    public bool IsActive => _enemys.Length > 0 && _processing == null;
    public KeyCode ButtonForActive => _buttonForActive;

    private Health _holder;

    private Health[] _enemys = new Health[0];
    private RaycastHit2D[] hits;

    private Health _currentEnemy;
    private IEnumerator _processing;
    private WaitForSeconds _waitForSecond;
    private float _currentTime;

    private void Awake()
    {
        _waitForSecond = new WaitForSeconds(_secondDelay);
        _holder = GetComponent<Health>();
    }

    private void OnDisable()
    {
        if(_processing != null)
        {
            StopCoroutine(_processing);
            _processing = null;
        }
    }

    private void Update()
    {
        if (Input.GetKey(_buttonForActive))
        {
            if (IsActive)
            {
                if(TryGetNearEnemy(out _currentEnemy))
                    Cast();
            }
        }
    }

    private void FixedUpdate()
    {
        FindEnemys();
    }

    private void FindEnemys()
    {
        for (int i = 0; i < _countRays; i++)
        {
            float angle = i * (360f / _countRays);

            Vector2 rayDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y + _rayOffsetY);

            hits = Physics2D.RaycastAll(rayPosition, rayDirection, _radius, _layerMask);
            Debug.DrawRay(rayPosition, rayDirection * _radius, Color.green);

            if (hits != null && hits.Length > 0)
            {
                _enemys = new Health[hits.Length];

                for (int j = 0; j < hits.Length; j++)
                {
                    if (hits[j].collider.TryGetComponent(out Health enemy))
                        _enemys[j] = enemy;
                }
            }
            else
            {
                _enemys = new Health[0];
            }
        }
    }

    private bool TryGetNearEnemy(out Health health)
    {
        health = null;

        if (IsActive == false)
            return false;

        float minDistance = Mathf.Infinity;

        foreach (var enemy in _enemys)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                health = enemy;
            }
        }

        return true;
    }

    private void Cast()
    {
        if (_currentEnemy == null)
            return;

        if(_processing == null)
        {
            _processing = Processing();
            StartCoroutine(_processing);
        }
    }

    private IEnumerator Processing()
    {
        _currentTime = _secondDuration;

        while (_currentTime >= 0)
        {
            _currentEnemy.TakeDamage(_damage);
            _holder.TakeHeal(_damage);

            yield return _waitForSecond;
            _currentTime--;
        }

        _processing = null;
    }
}
