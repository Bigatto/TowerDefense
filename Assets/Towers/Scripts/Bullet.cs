using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 70f;
    public GameObject impactEffect;

    private Enemy _target;
    private Tower _tower;

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
            HitTarget(_tower.damage);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void SetTower(Tower tower)
    {
        _tower = tower;
    }
    public void Seek(Transform target)
    {
        _target = target.GetComponent<Enemy>();
    }

    private void HitTarget(float damage)
    {
        _target.takeDamage(damage);
        Destroy(gameObject);
    }
}