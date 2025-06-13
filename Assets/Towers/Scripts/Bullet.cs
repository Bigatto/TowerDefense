using Base.Scripts;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 70f;
    public GameObject impactEffect;

    private Enemy _target;
    private float _damage;

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform target)
    {
        _target = target.GetComponent<Enemy>();
    }

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void HitTarget()
    {
        _target.GetComponent<HealthSystem>().TakeDamage(_damage);
        Destroy(gameObject);
    }
}