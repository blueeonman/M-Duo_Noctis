using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpForce, gcRadius;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform gc;
    public LayerMask jumpableLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(gc.position, gcRadius, jumpableLayer);

        if(Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if(Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("w") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
