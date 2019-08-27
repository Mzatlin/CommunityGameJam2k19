using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    RaycastHit2D hit;
    Ray2D lookRay;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookRay = new Ray2D(transform.position, transform.right);
        Debug.DrawRay(lookRay.origin, lookRay.direction, Color.red, 10f);
        if (Physics2D.Raycast(lookRay.origin, lookRay.direction, 1f))
        {

        } 
    }
}
