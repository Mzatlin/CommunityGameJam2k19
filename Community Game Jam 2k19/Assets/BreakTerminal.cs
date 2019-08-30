using UnityEngine;
using System;

public class BreakTerminal : MonoBehaviour
{
    HealthController health;
    public Animator terminalAnimation;
    TerminalActivation activate;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDeath;
        activate = GetComponent<TerminalActivation>();
    }

    void HandleDeath()
    {
        activate.isActivated = false;
        terminalAnimation.SetBool("IsDestroyed", true);
    }
}
