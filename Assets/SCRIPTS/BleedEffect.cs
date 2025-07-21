using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "StatusEffects/Bleed")]
public class BleedEffect : StatusEffect
{
    public float damagePerTick = 3f;
    public float tickInterval = 0.5f;

    public override void ApplyEffect(DamageableObject target)
    {
        target.StartCoroutine(BleedCoroutine(target));
    }

    private IEnumerator BleedCoroutine(DamageableObject target)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            target.TakeDamage(Mathf.RoundToInt(damagePerTick));
            yield return new WaitForSeconds(tickInterval);
            elapsed += tickInterval;
        }
        RemoveEffect(target);
    }

    public override void RemoveEffect(DamageableObject target)
    {
        // Можно добавить визуализацию окончания эффекта
    }
}
