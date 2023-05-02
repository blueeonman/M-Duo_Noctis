using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currenHealth;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    public Animator animator;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        currenHealth = maxHealth;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }
        //Attack only when player in sight?
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            //playerHealth.TakeDamage(damage);
        }
    }
    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        //play hurt animation
        animator.SetTrigger("Hurt");
        if(currenHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        // Die animation
        animator.SetBool("IsDead", true);
        
        Debug.Log(this.gameObject.name + "died!");
        //Disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
