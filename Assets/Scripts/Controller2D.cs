using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    const float skinWidth = 0.015f;

    public int horizontalRaycount = 4;
    public int verticalRaycount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    Collider2D collider;
    RaycastOrigins raycastOrigins;

    public LayerMask collisionMask;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        calculateRaySpacing();
    }
    void Update()
    {


    }

    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigins();

        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);

        }

        if (velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }

        transform.Translate(velocity);
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRaycount; i++)
        {
            Vector2 rayOrigin = (directionX == - 1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            if (hit)
            {
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;
            }

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

        }
    }

    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < verticalRaycount; i++)
        {
            Vector2 rayOrigin = (directionY == - 1)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
            }

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRightM = new Vector2(bounds.max.x, bounds.max.y);

    }

    void calculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRaycount = Mathf.Clamp(horizontalRaycount, 2, int.MaxValue);
        verticalRaycount = Mathf.Clamp(verticalRaycount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRaycount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRaycount - 1);

    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRightM;
        public Vector2 bottomLeft, bottomRight;
    }
}
