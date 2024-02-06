using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    PlayerInput input;
    Jumping jumping;
    Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        jumping = GetComponent<Jumping>();
    }

    private void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        if(jumping.isWallJumping)
        {
            Debug.Log("el pepeeee");
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(moveInput.x * speed, rb.velocity.y)), .5f * Time.deltaTime);
        }
        else rb.velocity = (new Vector2(moveInput.x * speed, rb.velocity.y));
    }
}
