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
        index = Mathf.Clamp(index, 0, 4);

        if (index > prompt.size-1)
        {
         //   index=prompt.size-1;
          //  var temp = cmdTextList[index - 1].text;
            //cmdTextList[index-1].text = prompt.textContent;
            //cmdTextList[index - 2].text = temp;
            int tempindex = prompt.size-1;

            for (int i = 0; i < prompt.size-1; i++)
            {
                cmdTextList[i].text = cmdTextList[i+1].text;
            }
            cmdTextList[tempindex].text = prompt.textContent;
        }
        else
        {
            cmdTextList[index].text = prompt.textContent;
            index++;
        }

    }


}
