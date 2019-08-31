using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalManager : MonoBehaviour
{
    [SerializeField]
    LoadingBarValue load;
    public List<GameObject> terminals = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<terminals.Count; i++)
        {
            terminals[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < terminals.Count; i++)
        {
            if (terminals[i].gameObject.activeInHierarchy && !terminals[i].GetComponent<TerminalActivation>().isActivated)
            {
                load.isActive = false;
            }
            else
            {
                load.isActive = true;
            }
        }
    }
}
