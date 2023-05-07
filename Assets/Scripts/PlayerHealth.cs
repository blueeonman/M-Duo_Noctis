using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public GameObject player;
    public Transform respawnPoint;
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Respawn();
        }

        void Respawn()
        {
           
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
                player.transform.position = respawnPoint.position;
            
        }
    }
}
