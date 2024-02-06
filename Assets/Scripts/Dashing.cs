using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dashing : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float duration;

    PlayerInput input;
    Vector2 moveInput;
    Rigidbody2D rb;
    StateManager state;
    Vector2 dir;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<StateManager>();
    }

    void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        if(state.currentState == StateManager.State.Dashing)
        {
            rb.velocity = dir.normalized * speed;
        }
    }

    void OnDash()
    {
        Debug.Log("ondash");
        Dash(moveInput.x, moveInput.y);
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
