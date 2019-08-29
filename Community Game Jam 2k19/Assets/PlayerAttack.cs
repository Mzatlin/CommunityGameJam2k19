using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimator;
    [SerializeField]
    GameObject attackCenter;
    [SerializeField]
    float attackRadius;
    [SerializeField]
    LayerMask layerToAttack;
    IHealth health;
    Collider2D[] objectsToHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetBool("IsAttacking", true);
            objectsToHit = Physics2D.OverlapCircleAll(attackCenter.transform.position,attackRadius,layerToAttack);
            foreach(var item in objectsToHit)
            {
                health = item.GetComponent<IHealth>();
                if(health != null)
                {
                    item.GetComponent<IHealth>().InputDamage(1);
                }
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            playerAnimator.SetBool("IsAttacking", false);
        }

    }
}
