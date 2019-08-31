using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScriptedEvent : MonoBehaviour
{
    [SerializeField]
    LoadingBarValue load;
    [SerializeField]
    TerminalManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.GetComponent<TerminalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(load.Value >= 0.1)
        {
            manager.terminals[0].SetActive(true);
        }
    }
}
