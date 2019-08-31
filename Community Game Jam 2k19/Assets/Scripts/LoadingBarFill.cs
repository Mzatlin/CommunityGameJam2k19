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
        loadValue.isSlow = false;
        loadValue.tickRate = 0.001f;
        loadValue.Color = Color.green;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (loadValue.isActive)
        {
            slider.image.color = loadValue.Color;
          /*  if (loadValue.isSlow)
            {
                slider.image.color = Color.yellow;
            }
            else
            {
                slider.image.color = Color.green;
            }*/
            loadValue.Value += loadValue.tickRate;
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
