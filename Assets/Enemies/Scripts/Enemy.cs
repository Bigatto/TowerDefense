using Base.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private float attackDamage;
    [SerializeField] private LayerMask baseLayer;
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private Image healthUi;
    private float _currentHealth;

    [Header("Money Reward")]
    public int money = 10;
    private Transform _target;
    private int _waypointIndex;
    private float _lastAttackTime;
    private HealthSystem _healthSystem;

    private void Start()
    {
        _target = Waypoints.points[0];
        _currentHealth = maxHealth;
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
            PlayerStats.Lives--;
            Destroy(gameObject);
            return;
        }

        _waypointIndex++;
        _target = Waypoints.points[_waypointIndex];
    }

    public void takeDamage()
    {
        maxHealth -= 1; //in the future this should be tower damage
        var currentHealthPercent = maxHealth / _currentHealth;

        var imageScale = healthUi.transform.localScale;
        imageScale.x = currentHealthPercent;
        healthUi.transform.localScale = imageScale;

        if (maxHealth <= 0)
        {
            PlayerStats.Money += money;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.firebrick;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}