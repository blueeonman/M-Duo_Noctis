using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isOnGround;
    private float jumpCount;
    public float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public bool canDash = true;
    public bool isDashing;
    public float dashDistance = 15f;
    public float doubleTapTime;
    private float maxJump = 1f;
    public float positionRadius;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    public Transform playerPos;

    KeyCode lastKeyCode;
    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;

    //KeyCode lastKeyCode;
    //[SerializeField] private Rigidbody2D rig;
    //[SerializeField] private Transform groundCheck;
   LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    public void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //Debug.Log($"1 Jump count = {jumpCount} e maxJump = {maxJump}");


        dashCount = startDashCount;
    }

    public void Update()
    {
       // isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, groundLayer);


        Vector2 pos = transform.position;
        pos.x += horizontal * speed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && jumpCount <= maxJump)
        {
            rig.velocity = Vector2.up * speed;
            jumpCount++;
            // Debug.Log($"2 Jump count = {jumpCount} e maxJump = {maxJump}");
        }


        if (Input.GetKey("a") || Input.GetKey("d"))
        {

            transform.position = pos;
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();


        // dash
        if (side == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {


                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    side = 2;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.D;
            }
        }
        else
        {
            if (dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                rig.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime;

                if (side == 1)
                {
                    rig.velocity = Vector2.left * dashSpeed;
                } else if (side == 2)
                {
                    rig.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D colisor)
    {

        jumpCount = 0;

      
    }

    

    /*public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        //rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);

      


    }

  

    public bool IsGrounded()
    {
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/
   

    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

 

  
}
