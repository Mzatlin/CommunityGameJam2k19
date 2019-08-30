using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }
}
