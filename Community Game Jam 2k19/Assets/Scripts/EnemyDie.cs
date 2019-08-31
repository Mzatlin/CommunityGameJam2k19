using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public AudioSource enemySource;
    public AudioClip enemyClip;
    HealthController health;
    FollowTarget target;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDeath;
        target = GetComponent<FollowTarget>();
        collider = GetComponent<Collider2D>();
    }

    void HandleDeath()
    {
        StartCoroutine(DeathEffect());
    }
    IEnumerator DeathEffect()
    {
        enemySource.clip = enemyClip;
        enemySource.Play();
        target.enabled = false;
        collider.enabled = false;
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
        target.enabled = true;
        collider.enabled = true;
    }
}
