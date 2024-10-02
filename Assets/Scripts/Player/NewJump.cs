using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewJump : MonoBehaviour
{
    [Header("Ground jump attributes")]
    [SerializeField] float jumpHeight;
    [SerializeField] float upwardGravity; 
    [SerializeField] float downwardGravity;
    [SerializeField] float lowJumpWeight;

    // [Header("Wall jump attributes")]
    // [SerializeField] Vector2 wallJumpPower = new Vector2(10.7f, 10f);
    // float wallDirectionX;

    float defaultGravity;
    public bool wannaJump { get; private set; }
    bool onGround;

    public static Action onJumped;

    #region Component variables
    Rigidbody2D rb;
    NewerColliding collision;
    Vector2 velocity;
    PlayerInput input;
    InputAction jump;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        collision = GetComponent<NewerColliding>();
        input = GetComponent<PlayerInput>();
        jump = input.currentActionMap.FindAction("Jump"); 

        defaultGravity = 1;
    }

    void FixedUpdate()
    {
        onGround = collision.onGround;
        velocity = rb.velocity;
        // wallDirectionX = collision.normal.x;

        if(wannaJump)
        {
            wannaJump = false;
            JumpAction();
        }

        if(rb.velocity.y > 0)
        {
            if(jump.IsPressed())
            {
                rb.gravityScale = upwardGravity; 
            }
            else{ rb.gravityScale = upwardGravity + lowJumpWeight; }
        }
        else if(rb.velocity.y < 0)
        {
            rb.gravityScale = downwardGravity;
        }
        else if(rb.velocity.y == 0)
        {
            rb.gravityScale = defaultGravity;
        }
        rb.velocity = velocity;
    }

    void OnJump()
    {
        onJumped?.Invoke();
        wannaJump = true;
    }

    void JumpAction()
    {
        if(onGround)
        {
            float jumpSpeed = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0);
            }
            velocity.y += jumpSpeed;
            
        }
        
    }
}
