using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemCollect : MonoBehaviour
{
    public event Action OnCollected = delegate { };
    PlayerInputController player;
    public AudioSource source;
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<PlayerInputController>();
        if(player != null && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            OnCollected();
        }
    }
}
