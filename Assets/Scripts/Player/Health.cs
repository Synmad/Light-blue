using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    StateManager state;
    int curHealth;
    
    
    public static Action onPlayerDeath;

    void Awake()
    {
        state = GetComponent<StateManager>();
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage, Transform enemyTransform)
    {
        Debug.Log(enemyTransform.gameObject.name);
        curHealth -= damage;
        if(curHealth <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }
}
