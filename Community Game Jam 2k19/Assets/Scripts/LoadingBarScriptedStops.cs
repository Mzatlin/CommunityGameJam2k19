using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScriptedStops : MonoBehaviour
{
    public LoadingBarValue load;
    public CmdPromptObject prompt;
    public GameObject player;
    public PlayerObject playerobject;
    public AudioSource spawnSound;
    public AudioClip spawnClip;
    public GameObject terminal;
    int count = 0;
    // Start is called before the first frame update
    void Awake()
    {
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(load.Value >=.1 && load.Value <= .11)
        {
            load.isActive = false;
            if(count < 1)
            {
                count++;
                StartCoroutine(ScriptedSpawns());
            }
        }

    }
    IEnumerator ScriptedSpawns()
    {
        yield return new WaitForSeconds(2f);
        prompt.CmdSetText("Loading Error Detected.");

        spawnSound.clip = spawnClip;
        player.SetActive(true);
        spawnSound.Play();
        playerobject.isStopped = false;
        playerobject.isHacking = false;
        terminal.SetActive(true);
    }
}
