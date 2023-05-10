using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserDamage : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public int damageAmount = 5;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if(isPlayer)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log(this.gameObject.name + "attacked" + collision.gameObject.name);
        }
    }
}
