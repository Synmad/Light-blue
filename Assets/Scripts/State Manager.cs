using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum State
    {
        Default,
        Dashing,
        WallJumping,
    }
    
    public State currentState {get; private set;}

    void Awake()
    {
        currentState = State.Default;
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
    }
}
