using System;
using System.Collections;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float timeToRespawn;
    public static Transform respawnLocation;
    StateManager state;
    BoxCollider2D boxCollider;
    public static Action onPlayerRespawn;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        state = GetComponent<StateManager>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    void OnEnable()
    {
        Health.onPlayerDeath += StartRespawn;
    }

    void StartRespawn()
    {
        StartCoroutine(Respawn());   
    }

    IEnumerator Respawn()
    {
        sprite.enabled = false;
        state.ChangeState(StateManager.State.Dead);
        boxCollider.enabled = false;

        yield return new WaitForSeconds(timeToRespawn);

        onPlayerRespawn?.Invoke();
        transform.position = respawnLocation.position;
        sprite.enabled = true;
        state.ChangeState(StateManager.State.Default);
        boxCollider.enabled = true;
    }

    void OnDisable()
    {
        Health.onPlayerDeath -= StartRespawn;
    }
}
