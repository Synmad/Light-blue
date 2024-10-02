using System;
using System.Collections;
using UnityEngine;

public class DeathTransitionController : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    void OnEnable()
    {
        Health.onPlayerDeath += StartTransition; 
    }

    void StartTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1.8f);
        animator.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1);
    }

    void OnDisable()
    {
        Health.onPlayerDeath -= StartTransition; 
    }
}
