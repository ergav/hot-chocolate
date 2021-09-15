using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    Controller2D controller;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = 0.4f;

    public float accelerationTimeAir = 0.2f;
    public float acelerationTimeGround = 0.1f;

    public float speed = 6;

    //public float fallMultiplier = 2;
    //public float lowJumpMultiplier = 2.5f;

    float velocityXSmoothing;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        //gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex,2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        //minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

    }

    void Update()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Horizontal"));

        if (Input.GetButtonDown("Jump") && controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
        }

        //Hold space higher jump
        if (Input.GetButtonUp("Jump") )
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }

        //Hold space higher jump (OLD VERSION)
        //if (velocity.y < 0)
        //{
        //    velocity += Vector3.up * gravity * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    velocity += Vector3.up * gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        float targetVelocityX = input.x * speed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?acelerationTimeGround:accelerationTimeAir);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
