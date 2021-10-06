using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    Controller2D controller;

    [SerializeField] float maxJumpHeight = 4;
    [SerializeField] float minJumpHeight = 1;
    [SerializeField] float timeToJumpApex = 0.4f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallJumpLeap;

    [SerializeField] float accelerationTimeAir = 0.2f;
    [SerializeField] float acelerationTimeGround = 0.1f;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = 0.25f;
    float timeToWallUnstick;

    [SerializeField] float speed = 6;

    //public float fallMultiplier = 2;
    //public float lowJumpMultiplier = 2.5f;

    float velocityXSmoothing;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;

    Vector2 directionalInput;

    [HideInInspector]public bool wallSliding;
    int wallDirX;

    PlayerAnimations playerAnimations;
    PlayerSound playerSound;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerSound = GetComponent<PlayerSound>();

        //gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        //minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
                if (playerSound != null)
                {
                    playerSound.Jump();
                }
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
                if (!playerAnimations.facingRight)
                {
                    if (wallDirX < 0)
                    {
                        playerAnimations.facingRight = true;
                    }
                }
                else
                {
                    if (wallDirX > 0)
                    {
                        playerAnimations.facingRight = false;
                    }
                }
                if (playerSound != null)
                {
                    playerSound.Jump();
                }
            }
            else
            {
                velocity.x = -wallDirX * wallJumpLeap.x;
                velocity.y = wallJumpLeap.y;
                if (playerSound != null)
                {
                    playerSound.Jump();
                }
            }
        }
        if (controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            if (playerSound != null)
            {
                playerSound.Jump();
            }
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    void Update()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);



        wallDirX = (controller.collisions.left)?-1:1;

        float targetVelocityX = directionalInput.x * speed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? acelerationTimeGround : accelerationTimeAir);

        wallSliding = false;

        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;

            }
        }





        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (wallSliding)
        //    {
        //        if (wallDirX == directionalInput.x)
        //        {
        //            velocity.x = -wallDirX * wallJumpClimb.x;
        //            velocity.y = wallJumpClimb.y;
        //        }
        //        else if (wallDirX == 0)
        //        {
        //            velocity.x = -wallDirX * wallJumpOff.x;
        //            velocity.y = wallJumpOff.y;
        //        }
        //        else
        //        {
        //            velocity.x = -wallDirX * wallJumpLeap.x;
        //            velocity.y = wallJumpLeap.y;
        //        }
        //    }
        //    if (controller.collisions.below)
        //    {
        //        velocity.y = maxJumpVelocity;
        //    }
        //}

        ////Hold space higher jump
        //if (Input.GetButtonUp("Jump"))
        //{
        //    if (velocity.y > minJumpVelocity)
        //    {
        //        velocity.y = minJumpVelocity;
        //    }
        //}


        //Hold space higher jump (OLD VERSION)
        //if (velocity.y < 0)
        //{
        //    velocity += Vector3.up * gravity * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    velocity += Vector3.up * gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;

        }
    }
}
