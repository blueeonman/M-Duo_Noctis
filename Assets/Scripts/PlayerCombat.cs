using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public CharacterAudioController characterAudioController;
    public float attackRange = 0.5f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;  
            }
        }
    }

    void Attack()
    {
        //play an attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<MeleeEnemy>() != null)
            {
                enemy.GetComponent<MeleeEnemy>().TakeDamage(attackDamage);
                characterAudioController.PlayEnemyHitSound();
                Debug.Log(this.gameObject.name + "hit" + enemy.name);
            }
            else if(enemy.GetComponent<FlyingEnemy>() != null)
            {
                enemy.GetComponent<FlyingEnemy>().TakeDamage(attackDamage);
                characterAudioController.PlayEnemyHitSound();
            }
            else if (enemy.GetComponent<BossHead>() != null)
            {
                enemy.GetComponent<BossHead>().TakeDamage(attackDamage);
            }
            
            
        }
    }

    private void OnDrawGizmos()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
