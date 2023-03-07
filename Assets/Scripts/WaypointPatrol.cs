using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //Reference NavMeshAgent and way points
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    //Keep track of waypoint index
    private int currentWaypointIndex;

    void Start()
    {
        //Set inital destination of nav mesh agent
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        //Check if nav mesh agent is at destination 
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Change waypoint index 
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            //Set destination for new waypoint
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
