using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 70f;
    [SerializeField] private GameObject impactEffect;

    private Enemy _target;

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

    private void HitTarget()
    {
        _target.health -= 1;
        if (_target.health <= 0)
        {
            PlayerStats.Money += _target.money;
            GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(_target.gameObject);
        }

        Destroy(gameObject);
    }
}