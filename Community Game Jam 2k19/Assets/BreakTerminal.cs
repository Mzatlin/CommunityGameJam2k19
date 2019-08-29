using UnityEngine;
using System;

public class BreakTerminal : MonoBehaviour
{
    HealthController health;
    public Animator terminalAnimation;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDeath;
    }

    void HandleDeath()
    {
        terminalAnimation.SetBool("IsDestroyed", true);
    }
}
