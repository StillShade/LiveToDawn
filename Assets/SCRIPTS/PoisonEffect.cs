using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "StatusEffects/Poison")]
public class PoisonEffect : StatusEffect
{
    public float damagePerSecond = 5f;

    public override void ApplyEffect(DamageableObject target)
    {
        // Запускаем корутину на цели
        target.StartCoroutine(PoisonCoroutine(target));
    }

    private IEnumerator PoisonCoroutine(DamageableObject target)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            target.TakeDamage(Mathf.RoundToInt(damagePerSecond));
            yield return new WaitForSeconds(1f);
            elapsed += 1f;
        }
        RemoveEffect(target);
    }

    public override void RemoveEffect(DamageableObject target)
    {
        // Можно добавить визуализацию окончания эффекта
    }
}
