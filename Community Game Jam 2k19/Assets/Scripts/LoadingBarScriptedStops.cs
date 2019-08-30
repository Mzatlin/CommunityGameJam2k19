using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScriptedStops : MonoBehaviour
{
    public LoadingBarValue load;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(load.Value >=.1 && load.Value <= .11)
        {
            load.isActive = false;
        }
  /*      if (load.Value >= .5 && load.Value <= .51)
        {
            load.isActive = false;
        }*/
    }
}
