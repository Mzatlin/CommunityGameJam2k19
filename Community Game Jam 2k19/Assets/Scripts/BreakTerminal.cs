using UnityEngine;
using System;

public class BreakTerminal : MonoBehaviour
{
    [SerializeField]
    CmdPromptObject cmd;
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
        cmd.CmdSetText("Terminal Down!");
    }
}
