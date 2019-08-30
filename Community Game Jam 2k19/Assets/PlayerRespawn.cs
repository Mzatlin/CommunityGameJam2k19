using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject spawnLocation;
    public PlayerObject player;
    public Animator playerAnimator;
    public SpriteRenderer sprite;
    HealthController health;
    PlayerDie despawn;
    void Start()
    {
        health = GetComponent<HealthController>();
        despawn = GetComponent<PlayerDie>();
        despawn.OnDespawn += HandleDespawn; 
    }

    void HandleDespawn()
    {
        StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(true);
        player.isStopped = false;
        player.isDead = false;
        playerAnimator.SetBool("IsDead", false);
        transform.position = spawnLocation.transform.position;
        health.IsDead = false;
        sprite.enabled = true;
    

    }

}
