using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //Stores a reference to the waypoint system
    [SerializeField] private Waypoint waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private Transform currentWayPoint;


    // Start is called before the first frame update
    void Start()
    {
        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
        transform.position = currentWayPoint.position;

        currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
        transform.LookAt(currentWayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
        {
            currentWayPoint = waypoints.GetNextWayPoint(currentWayPoint);
            transform.LookAt(currentWayPoint);
        }
    }
}
