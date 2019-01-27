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
    public bool isCrawling = false;
    public Light lightCone;
    public GameObject Textbox;

    

    private bool isClimbingStairs = false;
    private float originalLightIntensity;

    private Vector2 colliderOffsetStanding = new Vector2(-0.025f,0.0f);
    private Vector2 colliderScaleStanding = new Vector2(1.0f, 2.5f);
    private Vector2 colliderOffsetCrawling = new Vector2(0.1f, 0.0f);
    private Vector2 colliderScaleCrawling = new Vector2(2.5f, 1.5f);
    public Vector3 heightDiffCrawling;

    public Stairs CurrentStair { get; set; }

    private Vector3 orginalScale;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private CapsuleCollider2D collider;

    

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        orginalScale = transform.localScale;
        originalLightIntensity = (lightCone == null) ? 0 : lightCone.intensity;
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
        if(Input.GetAxis("Vertical") > 0.0f && CurrentStair != null && !isClimbingStairs)
        {
            isClimbingStairs = true;
            animator.SetBool("isClimbingStairs", isClimbingStairs);
            base.gravityModifier = 0;

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

        #region crawling
        if(Input.GetAxis("Vertical") < 0.0f && !isCrawling)
        {
            isCrawling = true;
            animator.SetBool("isCrawling", isCrawling);
            collider.direction = CapsuleDirection2D.Horizontal;
            collider.offset = colliderOffsetCrawling;
            collider.size = colliderScaleCrawling;
            transform.position += heightDiffCrawling;
            Textbox.transform.position -= heightDiffCrawling;
        }
        else if(Input.GetAxis("Vertical") >= 0.0f && isCrawling)
        {
            isCrawling = false;
            animator.SetBool("isCrawling", isCrawling);
            collider.direction = CapsuleDirection2D.Vertical;
            collider.offset = colliderOffsetStanding;
            collider.size = colliderScaleStanding;
            transform.position -= heightDiffCrawling;
            Textbox.transform.position += heightDiffCrawling;

        }
        #endregion crawling

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

        var curMaxSpeed = isCrawling ? crouchMaxSpeed : maxSpeed;
        targetVelocity = move * curMaxSpeed;
    }

    public new void FixedUpdate()
    {
        if (isClimbingStairs)
        {
            if (currentStairTicks < TicksOfStairClimbing)
            {
                transform.localScale *= 0.9998f;
                transform.position += Vector3.up * 0.08f;
                currentStairTicks++;
                if(currentStairTicks % 12 == 0)
                {
                    lightCone.intensity -= 1;
                }
            }
            else
            {
                transform.position = CurrentStair.targetPosition(); 
                isClimbingStairs = false;
                animator.SetBool("isClimbingStairs", isClimbingStairs);
                transform.localScale = orginalScale;
                gravityModifier = 2;
                lightCone.intensity = originalLightIntensity;
            }            
        }
        else
        {
            base.FixedUpdate();            
            transform.rotation = Quaternion.identity;
        }
    }
}