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
    public AudioSource deathSource;
    public AudioClip deathClip;
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDeath;
    }

    void HandleDeath()
    {
        deathSource.clip = deathClip;
        deathSource.Play();
        playerAnimator.SetBool("IsDead", true);
        player.isDead = true;
        player.isStopped = true;
        prompt.CmdSetText("Player Terminated. Spawning Another");
        StartCoroutine(Despawn());

    }
    IEnumerator Despawn()
    {


        //  gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(1.5f);
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
