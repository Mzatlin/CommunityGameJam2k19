using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashLevel : MonoBehaviour
{
    ActivateCountDown activate;
    [SerializeField]
    AudioSource levelSong;
    [SerializeField]
    CanvasGroup canvas;
    [SerializeField]
    Animator fadeAnimation;
    // Start is called before the first frame update
    void Start()
    {
        activate = GetComponent<ActivateCountDown>();
        activate.OnFailure += HandleFailure;
    }

    void HandleFailure()
    {
        StartCoroutine(Flash());   

  
        SceneManager.LoadScene("FailureScene", LoadSceneMode.Single);
    }
   IEnumerator Flash()
    {
        fadeAnimation.Play("Fade_In");
       // yield return new WaitForSeconds(1f);


        levelSong.Stop();
       Time.timeScale = 0.0000001f;
        yield return null;
    }
      
}
