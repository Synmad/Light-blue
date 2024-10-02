using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] int damage;

    public static Action<Transform> onPlayerHit;

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(damage, transform);
        }
    } 
}
