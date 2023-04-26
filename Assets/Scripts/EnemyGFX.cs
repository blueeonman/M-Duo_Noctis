using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public float xscale;
    public float yscale;
    public float zscale;
    // Start is called before the first frame update
    void Start()
    {
        float xscale = transform.localScale.x;
        float yscale = transform.localScale.y;
        float zscale = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1 * xscale, yscale, zscale);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(xscale, yscale, zscale);
        }
    }
}
