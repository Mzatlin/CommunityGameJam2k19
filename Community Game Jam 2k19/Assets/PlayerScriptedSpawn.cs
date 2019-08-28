using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptedSpawn : MonoBehaviour
{
    public LoadingBarValue loadbar;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       if(loadbar.Value > 0)
        {
            loadbar.Value = 0;
        }
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(loadbar.Value >= 0.1f)
        {
            player.SetActive(true);
        }
    }
}
