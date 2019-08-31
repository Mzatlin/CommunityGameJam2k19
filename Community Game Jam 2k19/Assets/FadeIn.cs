using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
    }
}
