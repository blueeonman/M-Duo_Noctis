using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    //[SerializeField] private int damage = 1;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    public AudioSource bossHurt;
    public Animator animator;
    public BossDeath bossDeath;
    //private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    private void Update()
    {
        /*cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }*/
        //Attack only when player in sight?
        
    }

    /*private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent <PlayerHealth>();
        }

        return hit.collider != null;
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    /*private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("player attacked!");
        }
    }*/
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bossHurt.Play();
        //play hurt animation
        //animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            bossDeath.bossDie();
        }

    }
}
