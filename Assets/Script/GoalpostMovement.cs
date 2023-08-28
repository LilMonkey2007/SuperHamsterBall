using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalpostMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    private void Update()
    {
        // Check if the agent has reached the current destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            SetRandomDestination(); // Set a new random destination
        }
    }

    private void SetRandomDestination()
    {
        // Calculate a new position along the figure 8 path
        float t = Time.time; // Time variable for animation
        float x = Mathf.Sin(t) * 10f; // Varying x position
        float z = Mathf.Cos(t * 2f) * 5f; // Z position for figure 8
        Vector3 destination = new Vector3(x, 0f, z);

        // Move the GameObject using NavMeshAgent
        navMeshAgent.SetDestination(destination);
    }
}