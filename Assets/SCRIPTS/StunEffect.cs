using UnityEngine;

[CreateAssetMenu(menuName = "StatusEffects/Stun")]
public class StunEffect : StatusEffect
{
    public override void ApplyEffect(DamageableObject target)
    {
        target.isStunned = true;
        // Можно добавить визуализацию
    }

    public override void RemoveEffect(DamageableObject target)
    {
        target.isStunned = false;
    }
}