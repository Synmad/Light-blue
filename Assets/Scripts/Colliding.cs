using System;
using Unity.VisualScripting;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    [SerializeField] LayerMask terrainLayer;
    [SerializeField] float collisionRadius;
    [SerializeField] Vector2 bottomOffset, rightOffset, leftOffset;

    [field:SerializeField] public bool onGround { get; private set; }
    [field:SerializeField] public bool onWall { get; private set; }
    [field:SerializeField] public bool onLeftWall { get; private set; }
    [field:SerializeField] public bool onRightWall { get; private set; }
    [field:SerializeField] public int wallSide { get; private set; }

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2) transform.position + bottomOffset, collisionRadius, terrainLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, terrainLayer)
            || Physics2D.OverlapCircle((Vector2) transform.position + rightOffset, collisionRadius, terrainLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, terrainLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2) transform.position + rightOffset, collisionRadius, terrainLayer);

        wallSide = onRightWall ? 1 : -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
