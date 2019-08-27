using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarFill : MonoBehaviour
{
    public Slider slider;
    private Slider fill;
    public Text text;
    [SerializeField]
    private float progress;
    // Start is called before the first frame update
    void Awake()
    {
        if (slider == null)
        {
            Debug.LogError("No Slider is referenced!");

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        progress += 0.001f;
        progress = Mathf.Clamp(progress, 0f, .1f);
        slider.value = progress;
        text.text = (int)(progress * 100) + "%";
        if (progress >= .1)
        {
            slider.image.color = Color.red;
        }

        if (progress >= 1)
        {
            SceneManager.LoadScene("Ending Scene", LoadSceneMode.Single);
        }
    }
}
