using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public LayerMask collisionMask;

    public const float skinWidth = 0.015f;

    //const float dstBetweenRays = 0.1f;

    //[HideInInspector] public int horizontalRaycount;
    //[HideInInspector] public int verticalRaycount;

    public int horizontalRaycount = 4;
    public int verticalRaycount = 4;

    protected float horizontalRaySpacing;
    protected float verticalRaySpacing;

    protected Collider2D collider;
    protected RaycastOrigins raycastOrigins;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public virtual void Start()
    {
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

        //float boundsWidth = bounds.size.x;
        //float boundsHeight = bounds.size.y;

        //horizontalRaycount = Mathf.RoundToInt(boundsHeight / dstBetweenRays);
        //verticalRaycount = Mathf.RoundToInt(boundsWidth / dstBetweenRays);

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
