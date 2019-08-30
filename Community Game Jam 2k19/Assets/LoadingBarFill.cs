using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarFill : MonoBehaviour
{
    public Slider slider;
    public LoadingBarValue loadValue;
    private Slider fill;
    public Text text;
    public bool isActive;
    [SerializeField]
    private float progress;
    // Start is called before the first frame update
    void Awake()
    {
        if (slider == null)
        {
            Debug.LogError("No Slider is referenced!");

        }

        loadValue.Value = 0f;
        loadValue.isActive = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (loadValue.isActive)
        {
            slider.image.color = Color.green;
            loadValue.Value += 0.001f;
            loadValue.Value = Mathf.Clamp(loadValue.Value, 0f, 1f);
            slider.value = loadValue.Value;
            text.text = (int)(loadValue.Value * 100) + "%";
        }
        else
        {
            slider.image.color = Color.red;
        }
        if (loadValue.Value >= 1)
        {
            SceneManager.LoadScene("Ending Scene", LoadSceneMode.Single);
        }
    }
}
