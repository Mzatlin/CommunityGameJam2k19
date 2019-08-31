using UnityEngine;

[CreateAssetMenu]
public class LoadingBarValue : ScriptableObject
{
    public float Value;
    public Color Color = Color.green;
    public bool isSlow;
    public bool isActive;
    public float tickRate;
    
    public void Activate()
    {
        Value += .011f;
        isActive = true;
        if (isSlow)
        {
            Color = Color.yellow;
        }
        else
        {
            Color = Color.green;
        }

    }
}
