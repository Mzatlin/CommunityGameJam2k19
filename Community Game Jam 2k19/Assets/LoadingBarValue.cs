using UnityEngine;

[CreateAssetMenu]
public class LoadingBarValue : ScriptableObject
{
    public float Value;
    public Color Color = Color.green;
    public bool isActive;
    public float tickRate;
}
