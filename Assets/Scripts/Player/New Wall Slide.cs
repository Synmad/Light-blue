using Unity.VisualScripting;
using UnityEngine;

public class NewWallSlide : MonoBehaviour
{
    public bool wallJumping {get; private set; }

    [Header("Wall slide attributes")]
    [SerializeField] float speed;

    [Header("Wall jump attributes")]
    [SerializeField] Vector2 wallJumpPower = new Vector2(10.7f, 10f);
    float wallDirectionX;

    NewerColliding colliding;
    Rigidbody2D rb;
    NewJump jump;
    Walking walking;

    bool wannaJump;
    Vector2 velocity;

    void Awake()
    {
        colliding = GetComponent<NewerColliding>();
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<NewJump>();
        walking = GetComponent<Walking>();
    }

    void Update()
    {
        wannaJump = jump.wannaJump;
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        wallDirectionX = colliding.normal.x;

        if(colliding.onWall)
        {
            if(velocity.y < -speed)
            {
                velocity.y = speed;
            }
        }

        if((colliding.onWall && velocity.x == 0) || colliding.onGround)
        {
            wallJumping = false;
        }

        if(wannaJump)
        {
            velocity = new Vector2(wallJumpPower.x * -wallDirectionX, wallJumpPower.y);
            wallJumping = false;
            wannaJump = false;
        }
        rb.velocity = velocity;
    }
}
