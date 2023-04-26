using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hookable")
        {
            player.GetComponent<GrappleHook>().hooked = true;
            Debug.Log("Tocou");
        }
    }

}
