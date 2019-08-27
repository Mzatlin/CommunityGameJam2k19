using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Loading Scene",LoadSceneMode.Single);
    }
}
