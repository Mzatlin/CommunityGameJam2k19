using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu]
public class CmdPromptObject : ScriptableObject
{

    public int size;
    public string textContent;
    public event Action OnTextChange = delegate {}; 
    public void CmdSetText(string content)
    {
        textContent = content;
        OnTextChange();
    }

}
