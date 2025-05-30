using UnityEngine;

public class waypoints : MonoBehaviour
{
    public static Transform[] points;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
