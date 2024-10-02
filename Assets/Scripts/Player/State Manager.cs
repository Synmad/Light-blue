using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum State
    {
        Default,
        Dashing,
        WallJumping,
        Dead,
    }
    
    [field:SerializeField] public State currentState {get; private set;}

    void Awake()
    {
        currentState = State.Default;
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
    }
}
