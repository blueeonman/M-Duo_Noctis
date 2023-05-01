using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;


    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
