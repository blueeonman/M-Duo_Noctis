using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public GameObject objectToSpawn;
    public Sprite newSprite;
    bool playerColliding;
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    void SpawnObject(GameObject newObject)
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation); ;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerColliding)

        {
            ChangeSprite(newSprite);
            SpawnObject(objectToSpawn);
        }
    }

    void OnColliderEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerColliding = true;
        }
    }

    void OnColliderExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerColliding = false;
        }
    }
    

}
