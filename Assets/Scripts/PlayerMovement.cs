using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isOnGround;
    private float jumpCount;
    public float horizontal;
    [SerializeField] float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public bool canDash = true;
    public bool isDashing;
    public float dashDistance = 15f;
    public float doubleTapTime;
    private float maxJump = 1f;
    public float positionRadius;
    public FlipSprite flipSprite;
    public BoxCollider2D boxCollider2D;
    private Rigidbody2D rig;
    public bool isGrounded;
    public Animator animator;

    public float radius;
   // [SerializeField] float speed1 = 5f;

    public Transform hookPoint;
    public float sinTime;

    public float angle = 0;
    public Vector2 velocity;

    public float direction;
    public LineRenderer lineRenderer;

    public Texture2D texture2D;
    /* private SpriteRenderer sr;
     public Transform playerPos;

     KeyCode lastKeyCode;
     public float dashSpeed;
     private float dashCount;
     public float startDashCount;
     private int side;*/

    //KeyCode lastKeyCode;
    //[SerializeField] private Rigidbody2D rig;
    //[SerializeField] private Transform groundCheck;

    GrappleHook gh;

    
    float my;

    LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    public void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        
        //  sr = GetComponent<SpriteRenderer>();
        //Debug.Log($"1 Jump count = {jumpCount} e maxJump = {maxJump}");


        // dashCount = startDashCount;
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
            animator.SetTrigger("Jump");
            // Debug.Log($"2 Jump count = {jumpCount} e maxJump = {maxJump}");
        }


        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            transform.position = pos;
        }




        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("xSpeed", Mathf.Abs(horizontal * speed));
        animator.SetBool("Grounded", isGrounded);
        flipSprite.Flip();


       
     }
    void OnCollisionEnter2D(Collision2D other)
    {
        jumpCount = 0;
        isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }






    /*public void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        //rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);




    }


*/
    public bool IsGrounded()
        {
        float extraHeightTest = 0.01f;
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightTest);
        Color rayColor;
            if (hit.collider != null)
                {
                    rayColor = Color.green;
                }
            else
                {
                    rayColor = Color.red;
                }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest));
        return hit.collider != null;
        }

    /*
        /*public void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                Vector3 localScale = transform.localScale;
                isFacingRight = !isFacingRight;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }*/

    private void SetStartingAngle()
    {
        float dx = transform.position.x - hookPoint.position.x;
        float dy = transform.position.y - hookPoint.position.y;

        angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        if (angle < 0)
            angle += 360;

        sinTime = (angle * 2) / 100;

        //Sets starting direction
        if (angle > 270)
            direction = -1;
        else
            direction = 1;
    }


   /* private void FixedUpdate()
    {
        if (!gh.retracting)
        {
            rig.velocity = new Vector2(horizontal, my).normalized * speed;
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }*/

}
