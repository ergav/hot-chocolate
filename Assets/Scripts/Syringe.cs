using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    public Vector3[] localWaypoints;
    Vector3[] globalWayPoints;

    float speed;
    public float fallSpeed;
    public float ascendSpeed;
    public float waitTime;
    public float waitTimeUp;
    public float initialWaitTime;

    [Range(0, 2)] public float easeAmount;

    int fromWaypointIndex;
    float percentBeweenWaypoints;
    float nextMoveTime;

    bool playerNearby;

    public bool fall;

    public bool moving;

    Vector3 velocity;

    private void Start()
    {
        globalWayPoints = new Vector3[localWaypoints.Length];
        for (int i = 0; i < localWaypoints.Length; i++)
        {
            globalWayPoints[i] = localWaypoints[i] + transform.position;
        }

    }

    void Update()
    {
        if (playerNearby)
        {
            velocity = CalculatePlatformMovement();

            moving = true;

            transform.Translate(velocity);
        }
        else if ((!playerNearby && !fall) || moving)
        {
            velocity = CalculatePlatformMovement();

            transform.Translate(velocity);
        }


        if (fromWaypointIndex == 0)
        {
            fall = true;
        }
        else
        {
            fall = false;
        }

        if (fall)
        {
            speed = fallSpeed;
        }
        else
        {
            speed = ascendSpeed;
        }
    }

    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    Vector3 CalculatePlatformMovement()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }

        fromWaypointIndex %= globalWayPoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % globalWayPoints.Length;
        float distanceBetweenWaypoints = Vector3.Distance(globalWayPoints[fromWaypointIndex], globalWayPoints[toWaypointIndex]);
        percentBeweenWaypoints += Time.deltaTime * speed / distanceBetweenWaypoints;
        percentBeweenWaypoints = Mathf.Clamp01(percentBeweenWaypoints);
        float easedPercentBetweenWaypoints = Ease(percentBeweenWaypoints);

        Vector3 newPos = Vector3.Lerp(globalWayPoints[fromWaypointIndex], globalWayPoints[toWaypointIndex], easedPercentBetweenWaypoints);

        if (percentBeweenWaypoints >= 1)
        {
            percentBeweenWaypoints = 0;
            fromWaypointIndex++;

            moving = false;

            if (fall)
            {
                nextMoveTime = Time.time + waitTime;
            }
            else
            {
                nextMoveTime = Time.time + waitTimeUp;
            }

        }

        return newPos - transform.position;
    }

    public void DetectPlayer()
    {
        nextMoveTime = Time.time + initialWaitTime;
        playerNearby = true;
    }

    public void LosePlayer()
    {
        playerNearby = false;
    }

    private void OnDrawGizmos()
    {
        if (localWaypoints != null)
        {
            Gizmos.color = Color.red;
            float size = 0.3f;

            for (int i = 0; i < localWaypoints.Length; i++)
            {
                Vector3 globalWaypointPosition = (Application.isPlaying) ? globalWayPoints[i] : localWaypoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPosition - Vector3.up * size, globalWaypointPosition + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPosition - Vector3.left * size, globalWaypointPosition + Vector3.left * size);
            }
        }
    }
}
