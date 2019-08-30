using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandleInteraction : MonoBehaviour
{
    PlayerInteract interact;
    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<PlayerInteract>();
        interact.OnEnterInteraction += HandleEnter;
    }

    void HandleEnter()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
