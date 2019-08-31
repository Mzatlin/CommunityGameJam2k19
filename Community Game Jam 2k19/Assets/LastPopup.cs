using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPopup : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        StartCoroutine(Popup());
        
    }
    IEnumerator Popup()
    {
        yield return new WaitForSeconds(3);
        canvas.enabled = true;
        source.clip = clip;
        source.Play();
    }


}
