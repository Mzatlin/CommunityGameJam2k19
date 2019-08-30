using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmdPromptController : MonoBehaviour
{
    [SerializeField]
    CmdPromptObject prompt;
    [SerializeField]
    List<Text> cmdTextList = new List<Text>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        prompt.OnTextChange += HandleEnqueue;
    }

    // Update is called once per frame

    void HandleEnqueue()
    {

        if (index >= prompt.size)
        {
            var temp = cmdTextList[index - 1].text;
            cmdTextList[index-1].text = prompt.textContent;
            cmdTextList[index - 2].text = temp;
            index = 0;

            for (int i = prompt.size - 2; i >= 0; i--)
            {
                cmdTextList[index].text = cmdTextList[i].text;
                index++;
            }
        }
        else
        {
            cmdTextList[index].text = prompt.textContent;
            index++;
        }

    }


}
