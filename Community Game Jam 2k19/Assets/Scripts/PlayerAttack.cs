using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnimator;
    public PlayerObject player;
    public AudioSource attackAudio;
    public AudioClip audioClipAttack;
    public AudioClip hitClip;
    [SerializeField]
    GameObject attackCenter;
    [SerializeField]
    float attackRadius = 0.5f;
    [SerializeField]
    LayerMask layerToAttack;
    IHealth health;
    Collider2D[] objectsToHit;
    bool isDelayed = false;

    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !player.isStopped && !player.isHacking && !isDelayed)
        {
            attackAudio.clip = audioClipAttack;
            playerAnimator.Play("Player_Attack");
            attackAudio.Play();
            player.isStopped = true;
            objectsToHit = Physics2D.OverlapCircleAll(attackCenter.transform.position,attackRadius,layerToAttack);
            foreach(var item in objectsToHit)
            {
                health = item.GetComponent<IHealth>();
                if(health != null)
                {
                    attackAudio.clip = hitClip;
                    attackAudio.Play();
                    item.GetComponent<IHealth>().InputDamage(1);

                }
            }
            StartCoroutine(PausePlayer());
        }
    }
    IEnumerator PausePlayer()
    {
        isDelayed = true;
        yield return new WaitForSeconds(.18f);
        player.isStopped = false;
        isDelayed = false;
    }
}
