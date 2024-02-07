using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dashing : MonoBehaviour
{
    bool isDashing;
    Rigidbody2D rb;
    [SerializeField] float power;
    [SerializeField] float duration;
    [SerializeField] float cooldown;
    bool canDash = true;

    PlayerInput input;
    Vector2 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    void OnDash()
    {
        if(canDash)
        {
            isDashing = true;
            // canDash = false;
            dir = input.actions["Move"].ReadValue<Vector2>();
            if(dir == Vector2.zero)
            {
                dir = new Vector2(transform.localScale.x, 0);
            }
            rb.AddForce(dir.normalized * power);
            // StartCoroutine(StopDashing());
        }
    }

    // void Update()
    // {
    //     if(isDashing)
    //     {
    //         rb.AddForce(dir.normalized * power);
    //         return;
    //     }
    // }

    // IEnumerator StopDashing()
    // {
    //     yield return new WaitForSeconds(duration);
    //     isDashing = false;
    // }
}
