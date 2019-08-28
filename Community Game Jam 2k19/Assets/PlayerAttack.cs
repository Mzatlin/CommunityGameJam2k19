using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimator;
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
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            playerAnimator.SetBool("IsAttacking", false);
        }

    }
}
