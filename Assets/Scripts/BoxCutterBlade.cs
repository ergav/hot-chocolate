using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCutterBlade : MonoBehaviour
{
    [SerializeField] Vector3[] localWaypoints;
    Vector3[] globalWayPoints;

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
        globalWayPoints = new Vector3[localWaypoints.Length];
        for (int i = 0; i < localWaypoints.Length; i++)
        {
            globalWayPoints[i] = localWaypoints[i] + transform.position;
        }

        nextMoveTime = Time.time + initialWaitTime;

    }

    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    void Update()
    {
        Vector3 velocity = CalculateBladeMovement();

        transform.Translate(velocity);
    }

    Vector3 CalculateBladeMovement()
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
            if (!cyclic)
            {
                if (fromWaypointIndex >= globalWayPoints.Length - 1)
                {
                    fromWaypointIndex = 0;
                    System.Array.Reverse(globalWayPoints);
                }
            }
            nextMoveTime = Time.time + waitTime;



        }

        return newPos - transform.position;

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
