using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustpatral;
    private bool mustTurn;

    public Rigidbody2D rd;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    void Start()
    {
        mustpatral = true;
    }

    void Update()
    {
        if (mustpatral)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustpatral)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rd.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rd.velocity.y);
    }

    void Flip()
    {
        mustpatral = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustpatral = true;
    }
}
