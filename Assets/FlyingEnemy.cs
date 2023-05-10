using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int maxHealth = 1;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damage = 1;
    [SerializeField] private LayerMask playerLayer;
    public Animator animator;

    public Collider2D Collider;
    public PlayerHealth playerHealth;
    public int damageAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation
        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }

    void Die()
    {
        // Die animation
        //animator.SetBool("IsDead", true);

        Debug.Log(this.gameObject.name + "died!");
        //Disable enemy
        GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);

    }
}
