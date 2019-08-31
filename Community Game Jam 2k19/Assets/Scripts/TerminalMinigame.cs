using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TerminalMinigame : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    Image raisedKey;
    [SerializeField]
    Image pressedKey;
    public event Action OnComplete = delegate { };
    [SerializeField]
    Canvas minigameCanvas;
    [SerializeField]
    PlayerObject player;
    TerminalReceiveInteraction terminal;
    bool isComplete = false;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    public float count = 0; 
    // Start is called before the first frame update
    void Awake()
    {
        terminal = GetComponent<TerminalReceiveInteraction>();
        terminal.OnTerminalUse += HandleUse;
        terminal.OnTerminalLeave += HandleLeave;
        minigameCanvas = GetComponentInChildren<Canvas>();
        minigameCanvas.enabled = false;
        pressedKey.enabled = false;
        slider = GetComponentInChildren<Slider>();
    }
    
    void HandleUse()
    {
        minigameCanvas.enabled = true;
        player.isHacking = true;
        isComplete = false;
        count = 0;
        source.clip = clip;
        source.Play();
    }
    void HandleLeave()
    {
        minigameCanvas.enabled = false;
        player.isHacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        count = Mathf.Clamp(count, 0, 10);
        slider.value = count/10;
        if (player.isHacking)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                count++;
                pressedKey.enabled = true;
                source.clip = clip2;
                source.Play();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                pressedKey.enabled = false;
            }
            if(count >= 10)
            {
                player.isHacking = false;
                isComplete = true;
            }
        }
        if (isComplete)
        {
            OnComplete();
            isComplete = false;
        }
        count -= 0.03f;
    }
}
