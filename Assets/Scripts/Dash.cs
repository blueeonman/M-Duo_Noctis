using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;

    private Rigidbody2D rig;
    private SpriteRenderer sr;
    public Transform playerPos;
    KeyCode lastKeyCode;
    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;
    public float doubleTapTime;
    public Animator animator;

   
        public void Start()
        {

            rig = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            //Debug.Log($"1 Jump count = {jumpCount} e maxJump = {maxJump}");


            dashCount = startDashCount;
        }
    

    void Update()
    {
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
                //animator.SetBool("isDashing", false);
            }
            else
            {
                dashCount -= Time.deltaTime;

                if (side == 1)
                {
                    rig.velocity = Vector2.left * dashSpeed;
                    StartCoroutine(DashAnims());
                }
                else if (side == 2)
                {
                    rig.velocity = Vector2.right * dashSpeed;
                    StartCoroutine(DashAnims());
                }
            }
        }
    }
    IEnumerator DashAnims()
    {
        
        animator.SetBool("IsDashing", true);
        yield return new WaitForSeconds(startDashCount);
        animator.SetBool("IsDashing", false);
    }
}





