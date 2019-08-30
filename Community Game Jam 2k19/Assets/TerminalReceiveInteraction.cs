using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerminalReceiveInteraction : MonoBehaviour, IInteractable
{
    public LoadingBarValue loadValue;
    TerminalActivation activate;
    public Animator terminalAnimator;
    HealthController health;
    public PlayerObject player;
    public event Action OnTerminalUse = delegate { };
    public event Action OnTerminalLeave = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        activate = GetComponent<TerminalActivation>();
    }

    // Update is called once per frame
    void Update()
    {
      if (player.isStopped)
        {
            OnTerminalLeave();
        }
    }

    public void Interact()
    {
        if (!activate.isActivated)
        {
            OnTerminalUse();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        OnTerminalLeave();
    }
}
