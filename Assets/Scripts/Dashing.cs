using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dashing : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float duration;

    [SerializeField] bool canDash;

    PlayerInput input;
    Vector2 moveInput;
    Rigidbody2D rb;
    StateManager state;
    Vector2 dir;
    NewColliding colliding;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<StateManager>();
        colliding = GetComponent<NewColliding>();
    }

    void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        if(state.currentState == StateManager.State.Default && colliding.GetOnGround())
        {
            canDash = true;
        }

        if(state.currentState == StateManager.State.Dashing)
        {
            rb.velocity = dir.normalized * speed;
            canDash = false;
        }
    }

    void OnDash()
    {
        Debug.Log("dash pressed");
        if(canDash)
        {
            Dash(moveInput.x, moveInput.y);
        }
    }

    void Dash(float x, float y)
    {
        Debug.Log("performing dash");
        state.ChangeState(StateManager.State.Dashing);
        rb.velocity = Vector2.zero;
        dir = new Vector2(x,y);
        if(dir == Vector2.zero)
        {
            dir = new Vector2(transform.localScale.x, 0);
        }
        StartCoroutine(StopDash());
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(duration);
        state.ChangeState(StateManager.State.Default);
    }
}
