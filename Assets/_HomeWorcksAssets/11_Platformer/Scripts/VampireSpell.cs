using Assets._HomeWorcksAssets._11_Platformer.Scripts;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class VampireSpell : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private int _secondDuration = 6;
    [SerializeField] private int _secondDelay = 1;
    [SerializeField] private float _damage = 2;

    [SerializeField] private KeyCode _buttonForActive = KeyCode.E;

    public bool IsActive => _enemys.Length > 0 && _processing == null;
    public KeyCode ButtonForActive => _buttonForActive;

    private Health _holder;

    private Health[] _enemys = new Health[0];
    private Collider2D[] _colliders;

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
        _colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        if(_colliders != null && _colliders.Length > 0)
        {
            _enemys = new Health[_colliders.Length];

            for (int i = 0; i < _colliders.Length; i++)
            {
                if (_colliders[i].TryGetComponent(out Health enemy))
                    _enemys[i] = enemy;
            }
        }
        else
        {
            _enemys = new Health[0];
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
