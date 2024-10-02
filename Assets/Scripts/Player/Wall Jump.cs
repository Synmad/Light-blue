using UnityEngine;

public class WallJump : MonoBehaviour
{
    [SerializeField] Vector2 wallJumpPower = new Vector2(10.7f, 10f);

    NewerColliding colliding;

    float wallDirectionX;

    void Awake()
    {
        colliding = GetComponent<NewerColliding>();
    }
}
