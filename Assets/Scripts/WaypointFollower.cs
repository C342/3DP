using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime); // Ensures gameplay is equal at all framerates
    }
}
