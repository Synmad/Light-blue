using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dashing : MonoBehaviour
{
    [SerializeField] float speed, duration;

    [SerializeField] bool canDash;
    public bool dashReady;

    public static Action onDash;

    PlayerInput input;
    Vector2 moveInput;
    Rigidbody2D rb;
    StateManager state;
    Vector2 dir;
    NewerColliding colliding;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<StateManager>();
        colliding = GetComponent<NewerColliding>();
    }

    void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        if(colliding.onGround && state.currentState != StateManager.State.Dashing)
        {
            dashReady = true;
        }

        if(state.currentState == StateManager.State.Dashing)
        {
            rb.velocity = dir.normalized * speed;
            canDash = false;
        }

        if(state.currentState == StateManager.State.Default && dashReady)
        {
            canDash = true;
        }
    }

    void OnDash()
    {
        if(canDash)
        {
            onDash?.Invoke();
            dashReady = false;
            Dash(moveInput.x, moveInput.y);
        }
    }

    void Dash(float x, float y)
    {
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
