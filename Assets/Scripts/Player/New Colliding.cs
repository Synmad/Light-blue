using UnityEngine;

public class NewColliding : MonoBehaviour
{
    bool onGround; 

    void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    public bool GetOnGround()
    {
        return onGround;
    }
}
