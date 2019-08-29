using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmdPromptController : MonoBehaviour
{
    [SerializeField]
    CmdPromptObject prompt;
    [SerializeField]
    List<Text> cmdTextList;
    Queue<string> copyQueue;

    // Start is called before the first frame update
    void Start()
    {
      //  cmdTextList = new List<Text>();
    }

    // Update is called once per frame
    void Update()
    {
                
        for(int i = 0; i<=prompt.size-1; i++)
        {
            
            if(prompt.textQueue.Count > 0)
            {
                cmdTextList[i].text = prompt.textQueue.Dequeue();
            }

        }
    }
}
