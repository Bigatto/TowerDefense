using Base.Scripts;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private float attackDamage;
    [SerializeField] private LayerMask baseLayer;
    public int health = 10;

    [Header("Money Reward")]
    public int money = 10;
    private Transform _target;
    private int _waypointIndex;
    private float _lastAttackTime;
    private HealthSystem _healthSystem;

    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        if (!IsInAttackRange())
        {
            Vector2 direction = _target.position - transform.position;
            transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);

            if (Vector2.Distance(transform.position, _target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
        else
        {
            if (Time.time - _lastAttackTime > attackRate)
            {
                AttackBase();
            }
        }
    }

    private bool IsInAttackRange()
    {
        var playerBaseToHit = Physics2D.CircleCast(transform.position, attackRange, Vector2.left).transform;
        _healthSystem = playerBaseToHit != null ? playerBaseToHit.transform.GetComponent<HealthSystem>() : null;

        return _healthSystem != null;
    }

    private void AttackBase()
    {
        if (_healthSystem != null)
        {
            _healthSystem.TakeDamage(attackDamage);
            _lastAttackTime = Time.time;
        }
    }

    private void GetNextWaypoint()
    {
        if (_waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _waypointIndex++;
        _target = Waypoints.points[_waypointIndex];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.firebrick;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}