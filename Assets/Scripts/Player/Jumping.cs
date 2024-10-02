using UnityEngine;
using UnityEngine.InputSystem;

public class Jumping : MonoBehaviour
{
    #region Ground jump variables
    [Header("Ground jump attributes")]
    [SerializeField] float jumpVelocity;
    [SerializeField] float fallGravMultiplier;
    [SerializeField] float lowJumpGravMultiplier;

    float timeSinceJumped;
    bool isJumping;
    bool jumpInputReleased;
    #endregion

    #region Wall jump variables
    [Header("Wall jump attributes")]
    [SerializeField] float jumpForce;

    [field:SerializeField] public bool isWallJumping { get; private set; }
    float wallJumpDirection;
    #endregion

    #region Component variables
    PlayerInput input;
    InputAction jump;
    Rigidbody2D rb;
    Colliding colliding;
    WallSlide slide;
    StateManager state;
    #endregion

    

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        jump = input.currentActionMap.FindAction("Jump"); 
        rb = GetComponent<Rigidbody2D>();
        colliding = GetComponent<Colliding>();
        slide = GetComponent<WallSlide>();
        state = GetComponent<StateManager>();
    }

    private void Update()
    {
        if(state.currentState != StateManager.State.Dashing) { JumpUpdate(); }
        WallJumpUpdate();
    }

    void JumpUpdate()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallGravMultiplier - 1) * Time.deltaTime;
        }
        if(rb.velocity.y > 0 && !jump.IsPressed())
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravMultiplier - 1) * Time.deltaTime;
        }

        timeSinceJumped -= Time.deltaTime;

        if(isJumping && rb.velocity.y < 0)
        {
            isJumping = false;
        }
    }

    void WallJumpUpdate()
    {
        if(slide.isSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
        }

        if(colliding.onGround)
        {
            isWallJumping = false;
        }
    }

    void OnJump()
    {
        if(CanJump())
        {
            rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            timeSinceJumped = 0;

        }

        if(colliding.onWall && !colliding.onGround)
        {
            Debug.Log("wall jump!");
            isWallJumping = true;

            Vector2 wallDir = colliding.onRightWall ? Vector2.left : Vector2.right;
            rb.velocity += (Vector2.up / 1.5f + wallDir / 1.5f) * jumpForce;

            // if(transform.localScale.x != wallJumpDirection)
            // {
            //     Vector3 localScale = transform.localScale;
            //     localScale.x = -1;
            //     transform.localScale = localScale;
            // }
        }
    }

    bool CanJump()
    {
        return colliding.timeSinceGrounded > 0 && !isJumping; 
    }
}
