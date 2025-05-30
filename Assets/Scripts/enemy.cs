using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    private int waypointIndex = 0;
    public int health = 10;


    void Start()
    {
        target = waypoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = waypoints.points[waypointIndex];
    }
}
