using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public const float skinWidth = 0.015f;

    public int horizontalRaycount = 4;
    public int verticalRaycount = 4;

    protected float horizontalRaySpacing;
    protected float verticalRaySpacing;

    public LayerMask collisionMask;

    protected Collider2D collider;
    protected RaycastOrigins raycastOrigins;

    public virtual void Start()
    {
        collider = GetComponent<Collider2D>();
        calculateRaySpacing();
    }


    public void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRightM = new Vector2(bounds.max.x, bounds.max.y);

    }

    public void calculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRaycount = Mathf.Clamp(horizontalRaycount, 2, int.MaxValue);
        verticalRaycount = Mathf.Clamp(verticalRaycount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRaycount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRaycount - 1);

    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRightM;
        public Vector2 bottomLeft, bottomRight;
    }
}
