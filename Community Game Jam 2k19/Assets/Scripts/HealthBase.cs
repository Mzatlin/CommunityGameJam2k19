using UnityEngine;
using System;

public abstract class HealthBase : MonoBehaviour, IHealth
{
    public event Action<float> OnHit = delegate { };

    public void InputDamage(int damageAmount)
    {
        ReceiveDamage(damageAmount);
    }
    protected virtual void ReceiveDamage(int damageAmount) 
    {
        OnHit(damageAmount);
    }
}
