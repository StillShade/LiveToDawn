using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }
    public AttackZone attackZone; // Присвой через инспектор

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AttackWithWeapon(Item weapon)
    {
        var target = attackZone.currentTarget;
        Debug.Log("Пробуем атаковать. Текущая цель: " + (target != null ? target.name : "null"));
        if (target == null || weapon == null)
        {
            Debug.Log("Нет цели или оружия для атаки!");
            return;
        }

        if (weapon is WeaponItem weaponItem)
        {
            int damage = weaponItem.damageProfile.GetDamageForTarget(target.data.targetType);
            Debug.Log($"Наносим {damage} урона по {target.name}");
            target.TakeDamage(damage);

            // --- Применяем эффекты с вероятностью ---
            // Например, только если цель — плоть (Flesh)
            if (target.data.targetType == TargetType.Flesh && weaponItem.effectsOnFlesh != null)
            {
                foreach (var effectWithChance in weaponItem.effectsOnFlesh)
                {
                    if (effectWithChance.effect == null) continue;
                    float roll = Random.value; // от 0 до 1
                    if (roll <= effectWithChance.chance)
                    {
                        target.AddEffect(effectWithChance.effect);
                        Debug.Log($"Наложен эффект: {effectWithChance.effect.effectName} на {target.name}");
                    }
                }
            }

            // --- Здесь можно добавить анимацию удара, звук и т.д. ---
        }
        else
        {
            Debug.LogWarning("Попытка атаковать неоружием!");
        }
    }
}