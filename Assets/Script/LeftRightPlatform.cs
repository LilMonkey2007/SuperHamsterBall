using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{
    public float moveDistance = 1.5f; // Distance to move left and right
    public float moveSpeed = 2.0f;    // Speed of movement

    private Vector3 originalPosition;
    private Vector3 leftTargetPosition;
    private Vector3 rightTargetPosition;
    private bool movingLeft = true;

    private void Start()
    {
        originalPosition = transform.position;
        leftTargetPosition = new Vector3(-moveDistance, originalPosition.y, originalPosition.z);
        rightTargetPosition = new Vector3(moveDistance, originalPosition.y, originalPosition.z);
    }

    private void Update()
    {
        Vector3 targetPosition;

        if (movingLeft)
        {
            targetPosition = leftTargetPosition;
            if (transform.position.x <= leftTargetPosition.x) // Check if moving left has reached the limit
            {
                movingLeft = false;
            }
        }
        else
        {
            targetPosition = rightTargetPosition;
            if (transform.position.x >= rightTargetPosition.x) // Check if moving right has reached the limit
            {
                movingLeft = true;
            }
        }

        // Move the platform between originalPosition and targetPosition
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}