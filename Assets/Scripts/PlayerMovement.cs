using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isGround;
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
    private Rigidbody2D rig;


    KeyCode lastKeyCode;
    //[SerializeField] private Rigidbody2D rig;
    //[SerializeField] private Transform groundCheck;
   // [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    public void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        //Debug.Log($"1 Jump count = {jumpCount} e maxJump = {maxJump}");
    }

    public void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");



       
        Vector2 pos = transform.position;
        pos.x += horizontal * speed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && jumpCount <= maxJump)
        {
            rig.velocity = Vector2.up * speed;
            jumpCount++;
           // Debug.Log($"2 Jump count = {jumpCount} e maxJump = {maxJump}");
        }

        if (Input.GetKey("a")|| Input.GetKey("d"))
        {
           
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
        if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            StartCoroutine(Dash(-1f));
        } else
        {
            doubleTapTime = Time.time + 0.5f;
        }

        lastKeyCode = KeyCode.A;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                StartCoroutine(Dash(1f));
        }
        else
        {
            doubleTapTime = Time.time + 0.5f;
        }

        lastKeyCode = KeyCode.D;

        Flip();
    }
    void OnCollisionEnter2D(Collision2D colisor)
    {

        jumpCount = 0;

      
    }

    

    public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        //rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);

      


    }

  

    /*public bool IsGrounded()
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

 

   IEnumerator Dash(float direction)
    {
        
    }
}
