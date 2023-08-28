using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private float wanderRadius = 20.0f;
    private float wanderInterval = 1.0f;
    private float lastWanderTime;
    private float detectionRadius = 30.0f;
    private float pushForce = 20.0f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastWanderTime = Time.time;
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            // Move towards the player if detected
            navMeshAgent.SetDestination(player.transform.position);
        }
        else if (Time.time - lastWanderTime > wanderInterval)
        {
            // Wander behavior if player is not in range
            SetRandomDestination();
            lastWanderTime = Time.time;
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRadius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Push the player back when bumped into by the AI
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}