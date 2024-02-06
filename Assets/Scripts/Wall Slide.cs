using UnityEngine;
using UnityEngine.InputSystem;

public class WallSlide : MonoBehaviour
{
    [SerializeField] float speed;

    [field:SerializeField] public bool isSliding {get; private set;}

    PlayerInput input;
    Vector2 moveInput;
    Colliding colliding;
    Rigidbody2D rb;

    void Awake()
    {
        colliding = GetComponent<Colliding>();
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        if(colliding.onWall && !colliding.onGround && moveInput.x != 0)
        {
            isSliding = true;
            rb.velocity = (new Vector2(rb.velocity.x, -speed));
        }
        else { isSliding = false; }
    }
}
