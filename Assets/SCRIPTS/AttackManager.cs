using Inventory;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager Instance { get; private set; }
    public AttackZone attackZone; // ������� ����� ���������

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AttackWithWeapon(Item weapon)
    {
        var target = attackZone.currentTarget;
        Debug.Log("������� ���������. ������� ����: " + (target != null ? target.name : "null"));
        if (target == null || weapon == null)
        {
            Debug.Log("��� ���� ��� ������ ��� �����!");
            return;
        }

        if (weapon is WeaponItem weaponItem)
        {
            int damage = weaponItem.damageProfile.GetDamageForTarget(target.data.targetType);
            Debug.Log($"������� {damage} ����� �� {target.name}");
            target.TakeDamage(damage);

            // --- ��������� ������� � ������������ ---
            // ��������, ������ ���� ���� � ����� (Flesh)
            if (target.data.targetType == TargetType.Flesh && weaponItem.effectsOnFlesh != null)
            {
                foreach (var effectWithChance in weaponItem.effectsOnFlesh)
                {
                    if (effectWithChance.effect == null) continue;
                    float roll = Random.value; // �� 0 �� 1
                    if (roll <= effectWithChance.chance)
                    {
                        target.AddEffect(effectWithChance.effect);
                        Debug.Log($"������� ������: {effectWithChance.effect.effectName} �� {target.name}");
                    }
                }
            }

            // --- ����� ����� �������� �������� �����, ���� � �.�. ---
        }
        else
        {
            Debug.LogWarning("������� ��������� ���������!");
        }
    }
}