using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDie : MonoBehaviour
{
    public event Action OnDespawn = delegate { };
    public CmdPromptObject prompt;
    public SpriteRenderer sprite;
    public GameObject spawnLocation;
    HealthController health;
    public PlayerObject player;
    public Animator playerAnimator;
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDeath;
    }

    void HandleDeath()
    {
        playerAnimator.SetBool("IsDead", true);
        player.isDead = true;
        player.isStopped = true;
        prompt.CmdSetText("Player died. Spawning Another");
        StartCoroutine(Despawn());

    }
    IEnumerator Despawn()
    {
      
        
    //  gameObject.SetActive(false);
       // sprite.enabled = false;
        yield return new WaitForSeconds(3f);
        OnDespawn();
        /*   //   sprite.enabled = true;
           Debug.Log("Respawning");
           playerAnimator.SetBool("IsDead", false);
           transform.position = spawnLocation.transform.position;
           player.isDead = false;
           health.IsDead = false;
           */
    }
}
