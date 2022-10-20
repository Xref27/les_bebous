using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Space]
    [Header("Ground")]
    public LayerMask groundLayer;
    public bool onGround;
    public Vector2 bottomOffset;
    public Vector2 collisionSizeGround;


    void FixedUpdate()
    {
        //check onGround
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, collisionSizeGround, 0f, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //ground gizmo
        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, collisionSizeGround);
    }
}
