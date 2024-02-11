using UnityEngine;
using UnityEngine.InputSystem;

public class NewJump : MonoBehaviour
{
    [SerializeField] float jumpHeight, upwardGravity, downwardGravity, lowJumpWeight;

    Rigidbody2D rb;
    NewColliding collision;
    Vector2 velocity;
    PlayerInput input;
    InputAction jump;

    float defaultGravity;
    bool wannaJump;
    bool onGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        collision = GetComponent<NewColliding>();
        input = GetComponent<PlayerInput>();
        jump = input.currentActionMap.FindAction("Jump"); 

        defaultGravity = 1;
    }

    void FixedUpdate()
    {
        onGround = collision.GetOnGround();
        velocity = rb.velocity;

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
