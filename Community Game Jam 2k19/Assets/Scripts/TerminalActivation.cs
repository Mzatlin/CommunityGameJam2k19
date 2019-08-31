using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalActivation : MonoBehaviour
{
    public CmdPromptObject cmd;
    public Animator terminalAnimator;
    public bool isActivated = false;
    public TerminalMinigame game;
    HealthController health;
    public LoadingBarValue loadValue;
    public AudioSource audio;
    public AudioClip clip;
    [SerializeField]
    Canvas minigameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        minigameCanvas = GetComponentInChildren<Canvas>();
        game = GetComponent<TerminalMinigame>();
        game.OnComplete += HandleCompletion;
    }

   void HandleCompletion()
    {
        terminalAnimator.SetBool("IsActivated", true);
        loadValue.Activate();
        health.IsDead = false;
        terminalAnimator.SetBool("IsDestroyed", false);
        minigameCanvas.enabled = false;
        isActivated = true;
        cmd.CmdSetText("Terminal Activated");
        audio.clip = clip;
        audio.Play();
    }
}
