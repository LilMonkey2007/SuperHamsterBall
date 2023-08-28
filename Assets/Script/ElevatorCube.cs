using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeAnimator : MonoBehaviour
{
    public float moveDistance = 17.5f; // Distance to move up and down
    public float animationSpeed = 2f; // Time it takes to complete one animation cycle
    public float waitTime = 2f; // Time to wait at the top and bottom

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timer;

    private IEnumerator Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(0f, moveDistance, 0f);

        while (true)
        {
            yield return StartCoroutine(MoveUpAndWait());
            yield return StartCoroutine(MoveDownAndWait());
        }
    }

    private IEnumerator MoveUpAndWait()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationSpeed)
        {
            float t = elapsedTime / animationSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure it reaches the exact target position
        yield return new WaitForSeconds(waitTime);
    }

    private IEnumerator MoveDownAndWait()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationSpeed)
        {
            float t = elapsedTime / animationSpeed;
            transform.position = Vector3.Lerp(targetPosition, startPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition; // Ensure it reaches the exact start position
        yield return new WaitForSeconds(waitTime);
    }
}
