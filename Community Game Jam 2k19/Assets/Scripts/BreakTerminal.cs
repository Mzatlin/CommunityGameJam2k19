using UnityEngine;
using System;

public class BreakTerminal : MonoBehaviour
{
    [SerializeField]
    CmdPromptObject cmd;
    HealthController health;
    public Animator terminalAnimation;
    public AudioSource source;
    public AudioClip clip;
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
        source.clip = clip;
        source.Play();
        activate.isActivated = false;
        terminalAnimation.SetBool("IsDestroyed", true);
        cmd.CmdSetText("Terminal Damaged.");
    }
}
