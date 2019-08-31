using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCountDownText : MonoBehaviour
{
    [SerializeField]
    CountDownObject count;
    Text countText;
    // Start is called before the first frame update
    void Start()
    {
        count.isCountDown = false;
        countText = GetComponent<Text>();
        countText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (count.isCountDown)
        {
            countText.enabled = true;
            countText.text = "Fatal Crash Possible In: "+count.countDownTime+" Seconds";
            if (count.isFailure)
            {
                countText.text = "Crash Imminent. Goodbye.";
            }
        }
        if (!count.isCountDown)
        {
            countText.enabled = false;
        }
    }
}
