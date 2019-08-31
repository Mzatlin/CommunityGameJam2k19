using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptedSpawn : MonoBehaviour
{
    public LoadingBarValue loadbar;
    public CmdPromptObject prompt;
    public GameObject player;
    public PlayerObject playerobject;
    public AudioSource spawnSound;
    public AudioClip spawnClip;
    // Start is called before the first frame update
    void Start()
    {
    
        if (loadbar.Value > 0)
        {
            loadbar.Value = 0;
        }
    }

 
}
