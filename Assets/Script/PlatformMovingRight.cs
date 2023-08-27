using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingRight : MonoBehaviour
{
    public float moveDistance = 20.0f; // Distance to move left and right
    public float moveSpeed = 5.0f;    // Speed of movement
    public float maxLeftPosition = 1.25f; // Maximum position to the left

    private Vector3 originalPosition;
    private Vector3 leftTargetPosition;
    private Vector3 rightTargetPosition;
    private bool movingRight = true;

    private void Start()
    {
        originalPosition = transform.position;
        leftTargetPosition = originalPosition + new Vector3(-moveDistance, 0, 0);
        rightTargetPosition = originalPosition + new Vector3(moveDistance, 0, 0);
    }

    private void Update()
    {
        Vector3 targetPosition;

        if (movingRight)
        {
            targetPosition = rightTargetPosition;
            if (transform.position.x >= originalPosition.x + moveDistance) // Check if moving right has reached the limit
            {
                movingRight = false;
            }
        }
        else
        {
            targetPosition = leftTargetPosition;
            if (transform.position.x <= originalPosition.x - maxLeftPosition) // Check if moving left has reached the limit
            {
                movingRight = true;
            }
        }

        // Move the platform between originalPosition and targetPosition
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}