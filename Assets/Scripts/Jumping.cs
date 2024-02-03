using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float fallGravMultiplier;
    [SerializeField] float lowJumpGravMultiplier;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallGravMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnJump()
    {
        Debug.Log("jump");
        rb.velocity = Vector2.up * jumpVelocity;
    }


}
