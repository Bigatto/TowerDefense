using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public void seek(Transform _target)
    {
        this.target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void hitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        target.GetComponent<enemy>().health -= 1;
        Debug.Log("Hit " + target.name + ", remaining health: " + target.GetComponent<enemy>().health);
        if (target.GetComponent<enemy>().health <= 0)
        {
            Destroy(target.gameObject);
        }        
        Destroy(gameObject);
    }
}
