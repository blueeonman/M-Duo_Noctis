using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform newRespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            playerHealth.NewRespawn(newRespawnPoint);
        }
    }
}
