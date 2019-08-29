using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnTouch : MonoBehaviour
{
    IHealth health;
    GameObject target;

    void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.gameObject;
        health = target.GetComponent<IHealth>();
        if(health != null)
        {
            target.GetComponent<IHealth>().InputDamage(1);
        }
    }
}
