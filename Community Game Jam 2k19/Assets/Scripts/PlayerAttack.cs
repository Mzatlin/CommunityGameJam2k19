using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerObject player;
    [SerializeField]
    GameObject attackCenter;
    [SerializeField]
    float attackRadius = 0.5f;
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

        if (Input.GetKeyDown(KeyCode.E) && !player.isStopped && !player.isHacking)
        {
            playerAnimator.Play("Player_Attack");
            player.isStopped = true;
            objectsToHit = Physics2D.OverlapCircleAll(attackCenter.transform.position,attackRadius,layerToAttack);
            foreach(var item in objectsToHit)
            {
                health = item.GetComponent<IHealth>();
                if(health != null)
                {
                    item.GetComponent<IHealth>().InputDamage(1);
                }
            }
            StartCoroutine(PausePlayer());
        }
    }
    IEnumerator PausePlayer()
    {
        yield return new WaitForSeconds(.1f);
        player.isStopped = false;
    }
}
