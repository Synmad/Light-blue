using UnityEngine;

public class TrailController : MonoBehaviour
{
    TrailRenderer trail;
    StateManager state;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        state = GetComponent<StateManager>();
    }

    void Update()
    {
        if(state.currentState == StateManager.State.Dashing)
        {
            trail.emitting = true;
        }
        else { trail.emitting = false; }
    }
    
}
