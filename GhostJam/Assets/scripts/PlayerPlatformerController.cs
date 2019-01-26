using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    
    public float crouchMaxSpeed = 2;
    public int ticksTilTakeOff = 60;
    public int TicksOfStairClimbing = 60;

    private int currentJumpTakeOffTicks = 0;
    private int currentStairTicks = 0;
    private bool isJumping = false;
    private bool inJump = false;

    private bool isClimbingStairs = false;

    public Stairs CurrentStair { get; set; }


    private SpriteRenderer spriteRenderer;
    private Animator animator;
    

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        #region jumpEnd
        // If one landed reset the jumping state
        if (grounded && inJump && currentJumpTakeOffTicks >= ticksTilTakeOff)
        {
            inJump = false;
            animator.SetBool("isJumping", inJump);
            currentJumpTakeOffTicks = 0;
        }
        #endregion jumpEnd

        #region stairs
        if(Input.GetAxis("Vertical") > 0 && CurrentStair != null)
        {
            isClimbingStairs = true;
            animator.SetBool("isClimbingStairs", isClimbingStairs);

            if (CurrentStair.isBottom)
            {
                currentStairTicks = 0;
            }
            else
            {
                currentStairTicks = (int) (TicksOfStairClimbing * 0.8);
            }
            return;
        }
        #endregion stairs

        #region jumping
        // Jumping Start 
        if (Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        // delay takeoff for jumps
        if(isJumping)
        {
            if (currentJumpTakeOffTicks < ticksTilTakeOff)
            {
                currentJumpTakeOffTicks++;
            }
            else
            {
                velocity.y = jumpTakeOffSpeed;
                inJump = true;
                isJumping = false;
                grounded = false;
            }
        }
        #endregion jumping

        #region xMovement
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.1f) : (move.x < -0.1f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        #endregion xMovement

        targetVelocity = move * maxSpeed;
    }

    public new void FixedUpdate()
    {
        if (isClimbingStairs)
        {
            if (currentStairTicks < TicksOfStairClimbing)
            {
                //TODO: move a little up and scale down
                currentStairTicks++;
            }
            else
            {
                transform.position = CurrentStair.targetLocation; 
                isClimbingStairs = false;
                animator.SetBool("isClimbingStairs", isClimbingStairs);
            }            
        }
        else
        {
            base.FixedUpdate();
            transform.rotation = Quaternion.identity;
        }
    }
}