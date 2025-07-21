using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string effectName;
    public float duration;

    public abstract void ApplyEffect(DamageableObject target);
    public abstract void RemoveEffect(DamageableObject target);
}