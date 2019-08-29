using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDie : MonoBehaviour
{
    public event Action OnDespawn = delegate { };
    public SpriteRenderer sprite;
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
        StartCoroutine(Despawn());

    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1f);
        OnDespawn();
        gameObject.SetActive(false);
        sprite.enabled = false;
    
    }
}
