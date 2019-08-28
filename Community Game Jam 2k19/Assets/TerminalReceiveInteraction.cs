using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalReceiveInteraction : MonoBehaviour, IInteractable
{
    public LoadingBarValue loadValue;
    public Animator terminalAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        terminalAnimator.SetBool("IsActivated",true);
        loadValue.Value += .01f;
        loadValue.isActive = true;
        Debug.Log("Interacted");
    }
}
