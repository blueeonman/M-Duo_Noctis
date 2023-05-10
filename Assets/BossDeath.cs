using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public GameObject bossPrefab;
    public AudioSource deathSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bossDie()
    {
        // Die animation
        deathSound.Play();
        //animator.SetBool("IsDead", true);

        Debug.Log(this.gameObject.name + "died!");
        //Disable enemy
        Destroy(bossPrefab.gameObject);

    }
}
