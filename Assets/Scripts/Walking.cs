using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;

    PlayerInput input;
    Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walk(moveInput);
    }

    void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }
}
