using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthController : HealthBase
{
    public event Action OnDie = delegate { };
    [SerializeField]
    private float maxHealth = 1f;
    [SerializeField]
    private float currentHealth = 1f;
    [SerializeField]
    private bool isDead;
    public float CurrentHealth
    {
        get { return currentHealth; }
        private set { currentHealth = value; }
    }
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }
    // Update is called once per frame

    protected override void ReceiveDamage(int damageAmount)
    {
        if (IsDead) return;
        base.ReceiveDamage(damageAmount);

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            IsDead = true;
            OnDie();
        }

    }
}
