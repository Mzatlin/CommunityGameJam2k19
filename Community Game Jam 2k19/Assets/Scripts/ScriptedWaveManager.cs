using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedWaveManager : MonoBehaviour
{
    public LoadingBarValue load;
    public CmdPromptObject prompt;
    public GameObject firstEnemy;
    public GameObject enemy;
    public GameObject collectInterruption;
    public GameObject spawnpoint;
    public AudioSource audio;
    int messagecount = 0;
    int messagecount2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(load.Value >= .15)
        {
            if (messagecount < 1)
            {
                audio.Play();
                firstEnemy.SetActive(true);
                firstEnemy.transform.position = spawnpoint.transform.position;
                enemy.SetActive(true);
                prompt.CmdSetText("Glitches Detected. Defend The Console");
                messagecount++;
            }
        }

        if(load.Value >= .30)
        {
            if(messagecount2 < 1)
            {
                collectInterruption.SetActive(true);
                messagecount2++;
            }
        }
    }
}
