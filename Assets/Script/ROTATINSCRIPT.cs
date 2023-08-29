using UnityEngine;

public class RollingPlatform : MonoBehaviour
{
    public float rollSpeed = 10.0f; // Speed of rolling in degrees per second
    public float minRoll = -25.0f;  // Minimum rolling angle
    public float maxRoll = 25.0f;   // Maximum rolling angle

    private float currentRoll = 0.0f;
    private bool rollingForward = true;

    private void Update()
    {
        // Calculate the rolling amount based on speed and direction
        float rollAmount = rollSpeed * Time.deltaTime;

        // Determine the direction of rolling
        int rollDirection = rollingForward ? 1 : -1;

        // Update the current roll
        currentRoll += rollDirection * rollAmount;

        // Ensure rolling stays within the specified range
        currentRoll = Mathf.Clamp(currentRoll, minRoll, maxRoll);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(0, currentRoll, 0);

        // Check for direction change
        if (currentRoll >= maxRoll || currentRoll <= minRoll)
        {
            rollingForward = !rollingForward;
        }
    }
}