using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class FlipSprite : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Flip()
    {
        if (playerMovement.isFacingRight && playerMovement.horizontal < 0f || !playerMovement.isFacingRight && playerMovement.horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            playerMovement.isFacingRight = !playerMovement.isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
