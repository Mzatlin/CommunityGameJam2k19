using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    RaycastHit2D hit;
    PlayerInputController player;
    IInteractable terminalInteract;
    public LayerMask mask;
    float lastDirection;
    // Start is called before the first frame update
    public event Action OnEnterInteraction = delegate { };

    void Start()
    {
        player = GetComponent<PlayerInputController>();
        lastDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {
        var lookRay = new Ray2D(transform.position, new Vector2(lastDirection, 0).normalized);
        if (player.playerMove != 0)
        {
            lastDirection = player.playerMove;
        }
        Debug.DrawRay(lookRay.origin, lookRay.direction, Color.red, 0.3f);

        hit = Physics2D.Raycast(lookRay.origin, lookRay.direction, 0.3f, LayerMask.GetMask("Terminal"));
    
        if (hit != false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                terminalInteract = hit.collider.gameObject.GetComponent<IInteractable>();
                if (terminalInteract != null)
                {
                    terminalInteract.Interact();
                    OnEnterInteraction();
                }
            }
        }
        
    }
}
