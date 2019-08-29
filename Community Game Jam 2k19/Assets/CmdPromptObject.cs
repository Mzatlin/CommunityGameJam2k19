using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CmdPromptObject : ScriptableObject
{
    public Queue<string> textQueue = new Queue<string>();
    public int size;

    public void EnqueueText(string content)
    {
        //  if (textQueue.Count+1 > size)
        //  {
        if (textQueue.Count > 0)
        {
            textQueue.Dequeue();
        }
        textQueue.Enqueue(content);
        //  }

    }

}
