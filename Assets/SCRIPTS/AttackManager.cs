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

            // Анимация удара и т.д.
        }
        else
        {
            // Можно залогировать ошибку или проигнорировать
            Debug.LogWarning("Попытка атаковать неоружием!");
        }
    }
}