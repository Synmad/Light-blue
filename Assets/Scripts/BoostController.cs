using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [SerializeField] float resetTime;
    BoxCollider2D boxCollider;
    SpriteRenderer sprite;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Dashing>().dashReady = true;
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        boxCollider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(resetTime);
        boxCollider.enabled = true;
        sprite.enabled = true;
    }
}
