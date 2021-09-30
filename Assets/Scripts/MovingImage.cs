using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingImage : MonoBehaviour
{

    public Transform[] wayPoints;

    public float speed;
    public float waitTime;
    public float initialWaitTime;
    [Range(0, 2)] public float easeAmount;

    public bool cyclic;

    int fromWaypointIndex;
    float percentBeweenWaypoints;
    float nextMoveTime;

    void Start()
    {
        nextMoveTime = Time.time + initialWaitTime;
    }

    void Update()
    {
        Vector3 velocity = CalculateImageMovement();

        transform.Translate(velocity);

    }

    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    Vector3 CalculateImageMovement()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }

        fromWaypointIndex %= wayPoints.Length;
        int toWaypointIndex = (fromWaypointIndex + 1) % wayPoints.Length;
        float distanceBetweenWaypoints = Vector3.Distance(wayPoints[fromWaypointIndex].position, wayPoints[toWaypointIndex].position);
        percentBeweenWaypoints += Time.deltaTime * speed / distanceBetweenWaypoints;
        percentBeweenWaypoints = Mathf.Clamp01(percentBeweenWaypoints);
        float easedPercentBetweenWaypoints = Ease(percentBeweenWaypoints);

        Vector3 newPos = Vector3.Lerp(wayPoints[fromWaypointIndex].position, wayPoints[toWaypointIndex].position, easedPercentBetweenWaypoints);

        if (percentBeweenWaypoints >= 1)
        {
            percentBeweenWaypoints = 0;
            fromWaypointIndex++;
            if (!cyclic)
            {
                if (fromWaypointIndex >= wayPoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    System.Array.Reverse(wayPoints);
                }
            }
            nextMoveTime = Time.time + waitTime;

        }

        return newPos - transform.position;
    }
}
