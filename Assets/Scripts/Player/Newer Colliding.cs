using System;
using Unity.VisualScripting;
using UnityEngine;

public class NewerColliding : MonoBehaviour
{
    [field:SerializeField] public bool onGround { get; private set; }
    [field:SerializeField] public bool onWall { get; private set; }
    public Vector2 normal { get; private set; }
    public static Action onLanded;

    void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        if(onGround)
        {
            onLanded?.Invoke();
        }
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        EvaluateCollision(collision);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        onWall = false;
    }

    public void EvaluateCollision(Collision2D collision)
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            normal = collision.GetContact(i).normal;
            if((normal.y) >= 0.9f) //esto checkea si la colision es una superficie plana
            {
                onGround = true;
            }
            onWall = Mathf.Abs(normal.x) >= 0.9f;
        }
    }
}
